using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBackupUtility.Root {
    public enum HistoryStatus {
        Complete,
        Aborted,
        InProgress,
        NotStarted
    }

    public interface IRoot {
        int Id { get; }
        string Name { get; set; }
        string Path { get; set; }
        bool Sub { get; set; }
        string Note { get; set; }
        void Backup();

        INameFilter CreateNameFilter(string filter, FilterType filterType, string note);
        void RemoveNameFilter(INameFilter nameFilter);
        IEnumerable<INameFilter> NameFilters { get; }

        IAttributeFilter CreateAttributeFilter(System.IO.FileAttributes filter, FilterType filterType, string note);
        void RemoveAttributeFilter(IAttributeFilter attributeFilter);
        IEnumerable<IAttributeFilter> AttributeFilters { get; }
    }
}
