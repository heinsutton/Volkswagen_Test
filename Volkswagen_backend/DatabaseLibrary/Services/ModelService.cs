using DatabaseLibrary.DatabaseModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrary.Services
{
    public interface IModelService
    {
        Task<Model?> GetVehicleModelById(int vehicleId);

        Task<List<Model>?> SearchVehicleModelByName(string name);

        Task<List<Model>?> GetAllVehicleModels();

        Task<Model?> CreateVehicleModel(string? vehicleModelName);

        Task DeleteVehicleModel(int id);

        Task<Model?> UpdateVehicleModel(int? id, string? vehicleModelName);
    }

    public class ModelService : IModelService
    {
        private readonly VolkswagenDbContext _context;

        public ModelService(VolkswagenDbContext context)
        {
            _context = context;
        }

        public async Task<Model?> CreateVehicleModel(string? vehicleModelName)
        {
            var vehicleNameParameter = new SqlParameter("vehicleName", vehicleModelName);

            await _context.Database.ExecuteSqlRawAsync("EXECUTE dbo.sp_Create_Model @vehicleName", vehicleNameParameter);

            return await _context.Models.FromSqlRaw("EXECUTE dbo.sp_Get_Model_By_Name @vehicleName, @vehicleMakeId", vehicleNameParameter).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task DeleteVehicleModel(int id)
        {
            if (id <= 0) return;

            var modelIdParameter = new SqlParameter("id", id);

            await _context.Database.ExecuteSqlRawAsync("EXECUTE dbo.sp_Delete_Model @id", modelIdParameter);
        }

        public async Task<Model?> GetVehicleModelById(int vehicleModelId)
        {
            var modelIdParameter = new SqlParameter("id", vehicleModelId);

            return await _context.Models.FromSqlRaw("EXECUTE dbo.Get_Models_By_Id @id", modelIdParameter).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<List<Model>?> SearchVehicleModelByName(string name)
        {
            var modelNameParameter = new SqlParameter("modelName", name);

            return await _context.Models.FromSqlRaw("EXECUTE dbo.sp_Get_Models_By_Name @modelName", modelNameParameter).AsNoTracking().ToListAsync();
        }

        public async Task<List<Model>?> GetAllVehicleModels()
        {
            return await _context.Models.FromSqlRaw("EXECUTE dbo.sp_Get_All_Models").AsNoTracking().ToListAsync();
        }


        public async Task<Model?> UpdateVehicleModel(int? id, string? vehicleModelName)
        {
            var modelIdParameter = new SqlParameter("id", id);
            var modelNameParameter = new SqlParameter("name", vehicleModelName);

            await _context.Database.ExecuteSqlRawAsync("EXECUTE dbo.sp_Update_VehicleModel @id, @name", modelIdParameter, modelNameParameter);

            return await _context.Models.FromSqlRaw("EXECUTE dbo.Get_Models_By_Id @id", modelIdParameter).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
