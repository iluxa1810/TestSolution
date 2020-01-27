using System;
using System.Collections.Generic;

namespace TestSolution
{
    public partial class StorageType
    {
        public StorageType()
        {
            Storage = new HashSet<Storage>();
        }

        public int StorageTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Storage> Storage { get; set; }
    }
}
