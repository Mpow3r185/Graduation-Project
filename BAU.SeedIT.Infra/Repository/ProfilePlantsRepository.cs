using Bau.Seedit.Core.Common;
using Bau.Seedit.Core.Data;
using BAU.SeedIT.Core.Data;
using BAU.SeedIT.Core.DTO;
using BAU.SeedIT.Core.RepositoryInterface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BAU.SeedIT.Infra.Repository
{
    public class ProfilePlantsRepository : IProfilePlantsRepository
    {
        private readonly IDbContext dbContext;

        public ProfilePlantsRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Plants AddPlant(int profileId, int plantId)
        {
            Plants profilePlants = GetPlantById(plantId);
            var parameters = new DynamicParameters();
            parameters.Add("@profile_id", profileId, dbType: DbType.Int64, direction: ParameterDirection.Input);
            parameters.Add("@plant_id", plantId, dbType: DbType.Int32, direction: ParameterDirection.Input);
             dbContext.Connection.Execute("addPlant", parameters, commandType: CommandType.StoredProcedure);
            return profilePlants;
         
        }

        public Plants GetPlantById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("plant_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            return dbContext.Connection.Query<Plants>("GetPlantById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        public List<Plants> getPlantsByProfileId(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("profile_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            return dbContext.Connection.Query<Plants>("getPlantsByProfileId", parameters, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
