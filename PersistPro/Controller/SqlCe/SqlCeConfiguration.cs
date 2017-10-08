using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Controller.SqlCe {
    public class SqlCeConfiguration : IConfiguration {
        private ConfigurationDataSet DataSet { get; set; }

        public SqlCeConfiguration(ConfigurationDataSet dataSet) {
            this.DataSet = dataSet;
        }

        #region IConfiguration Members

        public string this[string key] {
            get {
                var rows = this.DataSet.Configuration.Where(x => x.Key == key);
                if (rows.Count() == 1)
                    return rows.First().Value;
                else
                    return null;
            }
            set {
                var rows = this.DataSet.Configuration.Where(x => x.Key == key);
                if (rows.Count() == 1)
                    rows.First().Value = value;
                else
                    this.Add(key, value);
            }
        }

        public IEnumerable<string> Keys {
            get {
                foreach (string key in from x in this.DataSet.Configuration where x.RowState != System.Data.DataRowState.Deleted select x.Key)
                    yield return key;
            }
        }

        public void Add(string key, string value) {
            this.DataSet.Configuration.AddConfigurationRow(key, value);
        }

        public void Remove(string key) {
            this.DataSet.Configuration.FindByKey(key).Delete();
        }

        #endregion
    }
}
