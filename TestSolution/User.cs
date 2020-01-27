using System;
using System.Collections.Generic;

namespace TestSolution
{
    public partial class User
    {
        public User()
        {
            FolderScanHistory = new HashSet<FolderScanHistory>();
            StorageCurrentHolderUser = new HashSet<Storage>();
            StorageOwnerUser = new HashSet<Storage>();
            StorageUserHolderHistoryFromUser = new HashSet<StorageUserHolderHistory>();
            StorageUserHolderHistoryToUser = new HashSet<StorageUserHolderHistory>();
        }

        public int UserId { get; set; }
        public string Login { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual ICollection<FolderScanHistory> FolderScanHistory { get; set; }
        public virtual ICollection<Storage> StorageCurrentHolderUser { get; set; }
        public virtual ICollection<Storage> StorageOwnerUser { get; set; }
        public virtual ICollection<StorageUserHolderHistory> StorageUserHolderHistoryFromUser { get; set; }
        public virtual ICollection<StorageUserHolderHistory> StorageUserHolderHistoryToUser { get; set; }
    }
}
