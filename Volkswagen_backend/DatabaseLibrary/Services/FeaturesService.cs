using DatabaseLibrary.DatabaseModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrary.Services
{
    public interface IFeaturesService
    {
        public Task<Feature?> CreateFeature(string? featureName, int? vehicleId);

        public Task<Feature?> GetFeatureById(int Id);

        public Task<List<Feature>?> SearchFeaturesByName(string name);

        public Task<List<Feature>?> GetVehicleFeatures(int vehicleId);

        public Task<Feature?> UpdateFeature(int? id, string? featureName);

        public Task DeleteFeature(int Id);
    }

    public class FeaturesService : IFeaturesService
    {
        private readonly VolkswagenDbContext _context;

        public FeaturesService(VolkswagenDbContext context)
        {
            _context = context;
        }

        public async Task<Feature?> CreateFeature(string? featureName, int? vehicleId)
        {
            var featureNameParameter = new SqlParameter("featureName", featureName);
            if (vehicleId <= 0)
            {
                await _context.Database.ExecuteSqlRawAsync("EXECUTE dbo.sp_Create_Feature @featureName", featureNameParameter);
            }
            else
            {
                var vehicleIdParameter = new SqlParameter("vehicleId", vehicleId);

                await _context.Database.ExecuteSqlRawAsync("EXECUTE dbo.sp_Create_Feature @featureName, @vehicleId", featureNameParameter, vehicleIdParameter);
            }

            return await _context.Features.FromSqlRaw("EXECUTE dbo.sp_Get_Features_By_Name @featureName", featureNameParameter).FirstOrDefaultAsync();
        }

        public async Task DeleteFeature(int id)
        {
            if (id <= 0) return;

            var featureIdParameter = new SqlParameter("id", id);

            await _context.Database.ExecuteSqlRawAsync("EXECUTE dbo.sp_Delete_Feature @id", featureIdParameter);
        }

        public async Task<List<Feature>?> GetVehicleFeatures(int vehicleId)
        {
            var featureVehicleIdParameter = new SqlParameter("id", vehicleId);

            return await _context.Features.FromSqlRaw("EXECUTE sp_Get_Vehicle_Features @id", featureVehicleIdParameter).AsNoTracking().ToListAsync();
        }

        public async Task<Feature?> GetFeatureById(int id)
        {
            var featureId = new SqlParameter("id", id);

            return await _context.Features.FromSqlRaw("EXECUTE dbo.sp_Get_Feature_By_Id @id", featureId).FirstOrDefaultAsync();
        }

        public async Task<List<Feature>?> SearchFeaturesByName(string name)
        {
            var featureNameParameter = new SqlParameter("featureName", name);

            return await _context.Features.FromSqlRaw("EXECUTE dbo.sp_Get_Features_By_Name @featureName", featureNameParameter).ToListAsync();
        }

        public async Task<Feature?> UpdateFeature(int? id, string? featureName)
        {
            var featureIdParameter = new SqlParameter("id", id);
            var featureNameParameter = new SqlParameter("name", featureName);

            await _context.Database.ExecuteSqlRawAsync("EXECUTE dbo.sp_Update_Feature @id, @name", featureIdParameter, featureNameParameter);

            return await _context.Features.FromSqlRaw("EXECUTE dbo.sp_Update_Feature @id", featureIdParameter).FirstOrDefaultAsync();
        }
    }
}


//-OutputDir Models - Project DatabaseLibrary

//Scaffold-DbContext "Server=.\SQLExpress;Database=VolkswagenDb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DatabaseModels - Project DatabaseLibrary