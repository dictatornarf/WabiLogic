using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Controller {
    public delegate void ChangedHistoryHandler(object sender, EventArgs e);

    public class ClientExecutor : ExecutorBase {
        public ClientExecutor(IFactory factory) : this (factory, 20000.0) { }

        public ClientExecutor(IFactory factory, double pulseRate) : base(factory, pulseRate) { }

        public event ChangedHistoryHandler HistoryChanged;

        public override void Pulse() {
            //This should handle if errors occured in history and alerting user
            if (HistoryChanged != null)
                HistoryChanged(this, EventArgs.Empty);
        }
    }
}
