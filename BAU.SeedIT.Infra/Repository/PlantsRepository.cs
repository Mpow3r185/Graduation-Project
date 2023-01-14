using Bau.Seedit.Core.Common;
using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.DTO;
using Bau.Seedit.Core.RepositoryInterface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bau.Seedit.Infra.Repository
{
    public class PlantsRepository : IPlantsRepository
    {
        private readonly IDbContext dbContext;
        public PlantsRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public List<Plants> GetPlants()
        {
            IEnumerable<Plants> result = dbContext.Connection.Query<Plants>("GetPlants", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool addPlant(int profile_id, int plant_id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("profile_id", profile_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("plant_id", plant_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
             dbContext.Connection.Query<Plants>("GetPlantById", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public Plants GetPlantById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("plant_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            return dbContext.Connection.Query<Plants>("GetPlantById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
         
        }
        public List<Plants> SearchPlant(SearchPlantDTO plant)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@common_name", plant.plantName, dbType: DbType.String, direction: ParameterDirection.Input);
            return dbContext.Connection.Query<Plants>("SearchPlants", parameters, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
