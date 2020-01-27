using System;
using System.Collections.Generic;

namespace TestSolution
{
    public partial class Folder
    {
        public Folder()
        {
            FileDetail = new HashSet<FileDetail>();
            InverseFolderNavigation = new HashSet<Folder>();
        }

        public int FolderScanHistoryId { get; set; }
        public int FolderId { get; set; }
        public int StorageId { get; set; }
        public int Lvl { get; set; }
        public int Lvl444 { get; set; }
        public int Lvl4445 { get; set; }
        public string Name { get; set; }
        public string FolderPath { get; set; }
        public int TotalSubFolderCount { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime DateAdded { get; set; }
        public int? ParentFolderId { get; set; }

        public virtual Folder FolderNavigation { get; set; }
        public virtual FolderScanHistory FolderScanHistory { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual ICollection<FileDetail> FileDetail { get; set; }
        public virtual ICollection<Folder> InverseFolderNavigation { get; set; }
    }
}
