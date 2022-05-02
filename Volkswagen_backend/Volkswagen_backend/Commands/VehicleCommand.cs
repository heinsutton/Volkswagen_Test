namespace Volkswagen_backend.Commands
{
    public class VehicleCommand
    {
        public int? id { get; set; }
        public int? ModelId { get; set; }
        public string? RangeName { get; set; }
        public double? Price { get; set; }
        public int? StockAmount { get; set; }
    }
}
