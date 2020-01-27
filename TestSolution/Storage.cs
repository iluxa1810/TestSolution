using System;
using System.Collections.Generic;

namespace TestSolution
{
    public partial class Storage
    {
        public Storage()
        {
            ChangeLocationHistory = new HashSet<ChangeLocationHistory>();
            Folder = new HashSet<Folder>();
        }

        public int StorageId { get; set; }
        public long? TotalFreeSpace { get; set; }
        public long TotalSize { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? DateOfLastUpdate { get; set; }
        public DateTime DateAdded { get; set; }
        public string Description { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int StorageTypeId { get; set; }
        public int LocationId { get; set; }
        public int OwnerUserId { get; set; }
        public int CurrentHolderUserId { get; set; }

        public virtual User CurrentHolderUser { get; set; }
        public virtual Locaction Location { get; set; }
        public virtual StorageType LocationNavigation { get; set; }
        public virtual User OwnerUser { get; set; }
        public virtual ICollection<ChangeLocationHistory> ChangeLocationHistory { get; set; }
        public virtual ICollection<Folder> Folder { get; set; }
    }
}
