using System;
using System.Collections.Generic;

namespace TestSolution
{
    public partial class ChangeLocationHistory
    {
        public int ChangeLocationHistoryId { get; set; }
        public int StorageId { get; set; }
        public int LocationId { get; set; }
        public DateTime DateChange { get; set; }

        public virtual Locaction Location { get; set; }
        public virtual Storage Storage { get; set; }
    }
}
