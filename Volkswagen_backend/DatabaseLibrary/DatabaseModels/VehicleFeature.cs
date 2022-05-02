using System;
using System.Collections.Generic;

namespace DatabaseLibrary.DatabaseModels
{
    public partial class VehicleFeature
    {
        public int VehicleId { get; set; }
        public int FeatureId { get; set; }

        public virtual Feature Feature { get; set; } = null!;
        public virtual Vehicle Vehicle { get; set; } = null!;
    }
}
