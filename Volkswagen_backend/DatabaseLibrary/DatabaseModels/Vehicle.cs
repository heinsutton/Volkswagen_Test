using System;
using System.Collections.Generic;

namespace DatabaseLibrary.DatabaseModels
{
    public partial class Vehicle
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string RangeName { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockAmount { get; set; }

        public virtual Model Model { get; set; } = null!;
    }
}
