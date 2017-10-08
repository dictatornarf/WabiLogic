using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace PersistProClient {
    public class EventArgs<T> : EventArgs {
        public EventArgs(T value) {
            m_value = value;
        }

        private T m_value;

        public T Value {
            get { return m_value; }
        }
    }

    public class ViewState {
        private Stack<PersistProControlBase> ControlStack { get; set; }
        public Action<string> UpdateHelpScreen { get; set; }
        public Control ParentContainer { get; private set; }

        public delegate void ViewStateChangedEventHandler(object sender, EventArgs e);
        public event ViewStateChangedEventHandler ViewStateChanged;

        public event EventHandler<EventArgs<object>> ViewStateDataChanged;

        protected virtual void OnViewStateChanged() {
            if (this.ViewStateChanged != null)
                this.ViewStateChanged(this, EventArgs.Empty);
        }

        public ViewState(Control parentContainer, Action<string> updateHelpScreen) {
            this.ControlStack = new Stack<PersistProControlBase>();
            this.ParentContainer = parentContainer;
            this.UpdateHelpScreen = updateHelpScreen;
        }

        internal virtual void OnViewStateDataChanged(object data) {
            if (this.ViewStateDataChanged != null)
                this.ViewStateDataChanged(this, new EventArgs<object>(data));
        }

        public PersistProControlBase CurrentControl {
            get { return this.ControlStack.Peek(); }
        }

        public void MoveForward(PersistProControlBase nextControl) {
            this.ParentContainer.SuspendLayout();

            nextControl.Dock = DockStyle.Fill;
            UpdateHelpScreen(nextControl.Help);
            
            if (this.ControlStack.Count > 0)
                this.ParentContainer.Controls.Remove(this.ControlStack.Peek());

            this.ControlStack.Push(nextControl);
            this.ParentContainer.Controls.Add(nextControl);

            this.ParentContainer.ResumeLayout(true);

            OnViewStateChanged();
        }

        public void MoveBackward() {
            this.ParentContainer.SuspendLayout();

            string help = "";
            this.ParentContainer.Controls.Remove(this.ControlStack.Pop());
            if (this.ControlStack.Count > 0) {
                help = this.ControlStack.Peek().Help; 
                this.ParentContainer.Controls.Add(this.ControlStack.Peek());
            }

            this.ParentContainer.ResumeLayout(true);

            UpdateHelpScreen(help);
            OnViewStateChanged();
        }

        public void Reset() {
            this.ParentContainer.SuspendLayout();

            this.ParentContainer.Controls.Remove(this.ControlStack.Pop());

            while (this.ControlStack.Count > 1)
                this.ControlStack.Pop();

            string help = "";
            if (this.ControlStack.Count == 1) {
                help = this.ControlStack.Peek().Help;
                this.ParentContainer.Controls.Add(this.ControlStack.Peek());
            }

            this.ParentContainer.ResumeLayout(true);

            UpdateHelpScreen(help);
            OnViewStateChanged();
        }

        public int Count {
            get { return this.ControlStack.Count; }
        }

        public bool SaveCurrentControlChanges() {
            return this.ControlStack.Peek().SaveChanges();
        }

        public void CancelCurrentControlChanges() {
            this.ControlStack.Peek().Cancel();
        }
    }
}
