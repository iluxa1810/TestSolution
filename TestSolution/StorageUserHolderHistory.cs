using System;
using System.Collections.Generic;

namespace TestSolution
{
    public partial class StorageUserHolderHistory
    {
        public int StorageUserHolderHistoryId { get; set; }
        public int StorageId { get; set; }
        public DateTime DateChange { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }

        public virtual User FromUser { get; set; }
        public virtual User ToUser { get; set; }
    }
}
