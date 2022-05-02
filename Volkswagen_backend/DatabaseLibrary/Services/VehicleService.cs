using DatabaseLibrary.DatabaseModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrary.Services
{
    public interface IVehicleService
    {
        public Task<Vehicle?> CreateVehicle(int? modelId, string? rangeName, double? price, int? stockAmount);

        public Task<Vehicle?> GetVehiclesById(int id);

        public Task<List<Vehicle>?> SearchVehiclesByRangeName(string name);

        public Task<List<Vehicle>?> GetAllVehiclesByModel(int modelId);

        public Task<Vehicle?> UpdateVehicle(int? id, int? modelId, string? rangeName, double? price, int? stockAmount);

        public Task DeleteVehicle(int id);

        public Task<Vehicle?> UpdateVehicleStock(int? id, int? stockNumber);
    }

    public class VehicleService : IVehicleService
    {
        private readonly VolkswagenDbContext _context;

        public VehicleService(VolkswagenDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle?> CreateVehicle(int? modelId, string? rangeName, double? price, int? stockAmount)
        {
            var vehicleMakeIdParameter = new SqlParameter("vehicleModelId", modelId);
            var vehicleRangeNameParameter = new SqlParameter("rangeName", rangeName);
            var vehiclePriceParameter = new SqlParameter("price", price);
            var vehicleStockAmountParameter = new SqlParameter("stockAmount", stockAmount);

            await _context.Database.ExecuteSqlRawAsync("EXECUTE dbo.sp_Create_Vehicle @vehicleModelId, @rangeName, @price , @stockAmount",
                vehicleMakeIdParameter, vehicleRangeNameParameter, vehiclePriceParameter, vehicleStockAmountParameter);

            return await _context.Vehicles.FromSqlRaw("EXECUTE dbo.sp_Get_Vehicles_By_Name @rangeName", vehicleRangeNameParameter).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task DeleteVehicle(int id)
        {
            var vehicleIdParameter = new SqlParameter("id", id);

            await _context.Database.ExecuteSqlRawAsync("EXECUTE dbo.sp_Delete_Vehicle @id", vehicleIdParameter);
        }

        public async Task<List<Vehicle>?> GetAllVehiclesByModel(int modelId)
        {
            var vehicleModelIdParameter = new SqlParameter("modelId", modelId);

            return await _context.Vehicles.FromSqlRaw("EXECUTE dbo.sp_Get_Vehicles_By_Model @modelId", vehicleModelIdParameter).AsNoTracking().ToListAsync();
        }

        public async Task<Vehicle?> GetVehiclesById(int id)
        {
            var vehicleIdParameter = new SqlParameter("id", id);

            var result = await _context.Vehicles.FromSqlRaw("EXECUTE dbo.sp_Get_Vehicle_By_Id @Id", vehicleIdParameter).AsNoTracking().ToListAsync();
            return (result != null && result.Any()) ? result.FirstOrDefault() : null;
        }

        public async Task<Vehicle?> UpdateVehicleStock(int? id, int? stockNumber = 0)
        {
            var vehicleIdParameter = new SqlParameter("id", id);
            var vehicleStockNumberParameter = new SqlParameter("stockNumber", stockNumber);

            await _context.Database.ExecuteSqlRawAsync("EXECUTE dbo.sp_Update_Vehicle_Stock @Id, @stockNumber", vehicleIdParameter, vehicleStockNumberParameter);

            var result = await _context.Vehicles.FromSqlRaw("EXECUTE dbo.sp_Get_Vehicle_By_Id @Id", vehicleIdParameter).AsNoTracking().ToListAsync();
            return (result != null && result.Any()) ? result.FirstOrDefault() : null;
        }

        public async Task<List<Vehicle>?> SearchVehiclesByRangeName(string rangeName)
        {
            var vehicleRangeNameParameter = new SqlParameter("rangeName", rangeName);

            return await _context.Vehicles.FromSqlRaw("EXECUTE dbo.sp_Get_Vehicles_By_Name @rangeName", vehicleRangeNameParameter).AsNoTracking().ToListAsync();
        }

        public async Task<Vehicle?> UpdateVehicle(int? id, int? modelId, string? rangeName, double? price, int? stockAmount)
        {
            var vehicleIdParameter = new SqlParameter("vehicleId", id);
            var vehicleMakeIdParameter = new SqlParameter("vehicleModelId", modelId);
            var vehicleRangeNameParameter = new SqlParameter("rangeName", rangeName);
            var vehiclePriceParameter = new SqlParameter("price", price);
            var vehicleStockAmountParameter = new SqlParameter("stockAmount", stockAmount);


            await _context.Database.ExecuteSqlRawAsync("EXECUTE dbo.sp_Update_Vehicle @vehicleId, @vehicleModelId, @rangeName, @price , @stockAmount",
                vehicleIdParameter, vehicleMakeIdParameter, vehicleRangeNameParameter, vehiclePriceParameter, vehicleStockAmountParameter);

            return await _context.Vehicles.FromSqlRaw("EXECUTE dbo.sp_Get_Vehicle_By_Id @Id", vehicleIdParameter).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
