using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.PersistPro.WcfProxy;

namespace WabiLogic.PersistPro.Model.Wcf {
    public class WcfPlan : IPlan {
        private Guid PlanId { get; set; }
        private ProxyConnectionManager Proxy { get; set; }

        public WcfPlan(Guid id, ProxyConnectionManager proxy) {
            this.PlanId = id;
            this.Proxy = proxy;
        }

        public override bool Equals(object obj)
        {
            IPlan plan = obj as IPlan;
            if (plan != null && plan.Id == this.Id)
                return true;
            else
                return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #region IPlan Members

        public Guid Id {
            get { return this.PlanId; }
        }

        public IRoot Root {
            get {
                return new WcfRoot(this.Proxy.Perform<Guid>(x => x.PlanGetRootId(this.Id)), this.Proxy);
            }
            set {
                this.Proxy.Perform(x => x.PlanSetRootId(this.Id, value.Id));
            }
        }

        public IMount Mount {
            get {
                return WcfPlanManager.LoadMount(this.Proxy.Perform<Guid>(x => x.PlanGetMountId(this.Id)), this.Proxy);
            }
            set {
                this.Proxy.Perform(x => x.PlanSetMountId(this.Id, value.Id));
            }
        }

        public ISchedule Schedule {
            get {
                return new WcfSchedule(this.Proxy.Perform<Guid>(x => x.PlanGetScheduleId(this.Id)), this.Proxy);
            }
            set {
                this.Proxy.Perform(x => x.PlanSetScheduleId(this.Id, value.Id));
            }
        }

        #endregion
    }
}
