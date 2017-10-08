using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using WabiLogic.PersistPro.Controller;
using WabiLogic.PersistPro.Controller.SqlCe;
using System.ServiceModel;
using WabiLogic.PersistPro.WcfProxy;

namespace PersistProServer {
    public partial class PersistProService : ServiceBase {
        private ServiceHost Pipe { get; set; }
        private ServerExecutor Server { get; set; }

        public PersistProService() {
            InitializeComponent();
            this.Server = null;
        }

        protected override void OnStart(string[] args) {
            SqlCeFactory factory = new SqlCeFactory();

            if (this.Server == null)
                this.Server = new ServerExecutor(factory);

            if (this.Pipe == null) {
                this.Pipe = new ServiceHost(new PersistProWcfProxy(factory));
                //this.Pipe = new ServiceHost(new PersistProWcfProxy(factory), new Uri("http://localhost:8080/persistpro"));
                //this.Pipe.AddServiceEndpoint(typeof(IPersistProWcfProxy), new BasicHttpBinding(), "");
                //System.ServiceModel.Description.ServiceMetadataBehavior b = new System.ServiceModel.Description.ServiceMetadataBehavior();
                //b.HttpGetEnabled = true;
                //this.Pipe.Description.Behaviors.Add(b);
                //this.Pipe.AddServiceEndpoint(typeof(System.ServiceModel.Description.IMetadataExchange), System.ServiceModel.Description.MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
                this.Pipe.Open();
            }

            this.Server.Start();
        }

        protected override void OnStop() {
            if (this.Server != null)
                this.Server.Stop();

            if (this.Pipe != null) {
                this.Pipe.Close();
                this.Pipe = null;
            }

        }
    }
}
