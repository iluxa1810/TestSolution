using System;
using System.Collections.Generic;

namespace TestSolution
{
    public partial class LocationType
    {
        public LocationType()
        {
            Locaction = new HashSet<Locaction>();
        }

        public int LocationTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Locaction> Locaction { get; set; }
    }
}
