using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PersistProClient {
    //public abstract class PersistProControlBase : UserControl {
    //    public abstract bool SaveChanges();
    //}
    public class PersistProControlBase : UserControl {
        protected Label lblHeader;

        public PersistProControlBase() {
            //HACK: Since the InitializeComponent is private and I want this control to appear
            //everywhere, I simply move the relavent code up here.
            this.lblHeader = new Label();
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(12, 10);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(55, 24);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "[Title]";
 
            this.Controls.Add(this.lblHeader);

        }
    
        public virtual bool SaveChanges() { return true; }
        public virtual void Cancel() { }
        public string Help { get; set; }
        public virtual NavigationControl NavigationControlType() { return NavigationControl.SaveChangesAndCancel; }

        private void InitializeComponent() {
            this.lblHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(12, 10);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(62, 24);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "[Title]";
            // 
            // PersistProControlBase
            // 
            this.Controls.Add(this.lblHeader);
            this.Name = "PersistProControlBase";
            this.Size = new System.Drawing.Size(289, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }

}
