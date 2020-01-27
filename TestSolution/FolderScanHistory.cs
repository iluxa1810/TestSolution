using System;
using System.Collections.Generic;

namespace TestSolution
{
    public partial class FolderScanHistory
    {
        public FolderScanHistory()
        {
            Folder = new HashSet<Folder>();
        }

        public int FolderScanHistoryId { get; set; }
        public DateTime DateStartScan { get; set; }
        public DateTime? DateEndScan { get; set; }
        public int CreatorUserId { get; set; }

        public virtual User CreatorUser { get; set; }
        public virtual ICollection<Folder> Folder { get; set; }
    }
}
