using System;
using System.Collections.Generic;

namespace DatabaseLibrary.DatabaseModels
{
    public partial class Model
    {
        public Model()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
