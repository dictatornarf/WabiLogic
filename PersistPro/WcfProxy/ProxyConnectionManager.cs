using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.IO;
using System.Threading;

namespace WabiLogic.PersistPro.WcfProxy
{
    public class ProxyConnectionManager
    {
        private ChannelFactory<IPersistProWcfProxy> ChannelFactory { get; set; }
        private IPersistProWcfProxy Proxy { get; set; }

        public ProxyConnectionManager()
        {

        }

        public T Perform<T>(Func<IPersistProWcfProxy, T> proxyFunction)
        {
            //try to perform the action up to thirty times
            //in case there is a problem with the wcf layer.
            T toReturn = default(T);


            if (ChannelFactory == null || Proxy == null ||
                this.ChannelFactory.State == CommunicationState.Closed ||
                this.ChannelFactory.State == CommunicationState.Closing ||
                this.ChannelFactory.State == CommunicationState.Faulted)
            {
                RebuildChannel();
            }
            for (int i = 0; i < 30; i++)
            {
                try
                {
                    toReturn = proxyFunction(this.Proxy);
                }
                catch
                {
                    if (i == 29) throw; 
                    Thread.Sleep(1000);
                    RebuildChannel();
                }
            }
            return toReturn;
        }

        public void Perform(Action<IPersistProWcfProxy> proxyAction)
        {
            Perform<int>(delegate(IPersistProWcfProxy x) { proxyAction(x); return 0; });
        }

        private void RebuildChannel()
        {

            if (this.Proxy != null)
            {
                try
                {
                    //we are rebuilding so force close
                    (this.Proxy as IClientChannel).Abort();
                }
                catch { }
            }

            if (this.ChannelFactory != null)
            {
                try
                {
                    //we are rebuilding so force close
                    this.ChannelFactory.Abort();
                }
                catch { }
            }

            this.ChannelFactory = new ChannelFactory<IPersistProWcfProxy>("");
            this.Proxy = this.ChannelFactory.CreateChannel();
        }
    }
}
