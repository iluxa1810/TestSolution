using System;
using System.Collections.Generic;

namespace TestSolution
{
    public partial class Locaction
    {
        public Locaction()
        {
            ChangeLocationHistory = new HashSet<ChangeLocationHistory>();
            Storage = new HashSet<Storage>();
        }

        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? LocationTypeId { get; set; }

        public virtual LocationType LocationType { get; set; }
        public virtual ICollection<ChangeLocationHistory> ChangeLocationHistory { get; set; }
        public virtual ICollection<Storage> Storage { get; set; }
    }
}
