using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using WabiLogic.PersistPro.Model;
using Thread = System.Threading;

namespace WabiLogic.PersistPro.Controller {
    public abstract class ExecutorBase {
        protected IFactory Factory { get; set; }
        protected IPlanManager PlanManager { get; set; }
        protected IHistoryManager HistoryManager { get; set; }
        private Timer EventTimer { get; set; }
        private bool Running { get; set; }
        private double PulseRate { get; set; }

        protected System.Threading.Thread PulseThread { get; set; }

        public ExecutorBase(IFactory factory, double pulseRate) {
            this.Factory = factory;
            this.PulseRate = pulseRate;

            this.PlanManager = this.Factory.LoadPlanManager();
            this.HistoryManager = this.Factory.LoadHistoryManager();
        }

        public void Start() {
            this.Running = true;
            
            this.EventTimer = new Timer(this.PulseRate);
            this.EventTimer.Elapsed += new ElapsedEventHandler(EventTimer_Elapsed);
            this.EventTimer.AutoReset = true;

            this.EventTimer.Start();
        }

        public void Stop() {
            this.Running = false;
            this.EventTimer.Stop();
            if (this.PulseThread != null && 
            (this.PulseThread.ThreadState & Thread.ThreadState.Running) == Thread.ThreadState.Running) {
                try {
                    this.PulseThread.Abort();
                }
                catch {
                    //Ignore -- Sometimes this throws an exception but we should just rip this down anyway
                }
            }

            this.EventTimer.Close();
        }

        private void EventTimer_Elapsed(object sender, ElapsedEventArgs e) {
            try {
                this.PulseThread = System.Threading.Thread.CurrentThread;

                this.EventTimer.Stop();
                Pulse();
            }
            catch (System.Threading.ThreadAbortException) {
                System.Threading.Thread.ResetAbort();
            }
            catch (Exception t) {
                EventHandler<System.Threading.ThreadExceptionEventArgs> handler = ThreadException;
                if (handler != null)
                    handler(this, new System.Threading.ThreadExceptionEventArgs(t));
                else
                    throw;
            }
            finally {
                if (this.Running)
                    this.EventTimer.Start();

                this.PulseThread = null;
            }
        }

        public abstract void Pulse();

        public event EventHandler<System.Threading.ThreadExceptionEventArgs> ThreadException;

    }
}
