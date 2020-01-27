using System;
using System.Collections.Generic;

namespace TestSolution
{
    public partial class FileDetail
    {
        public int FileDetailId { get; set; }
        public int FolderScanHistoryId { get; set; }
        public int FolderId { get; set; }
        public string ExtensionName { get; set; }
        public int FileCount { get; set; }
        public long FileSize { get; set; }

        public virtual Folder Folder { get; set; }
    }
}
