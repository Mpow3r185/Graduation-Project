using Bau.Seedit.Core.Common;
using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.RepositoryInterface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bau.Seedit.Infra.Repository
{
    public class MyGardenRepository : IMyGardenRepository
    {
        private readonly IDbContext dbContext;

        public MyGardenRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<MyGarden> GetMyGarden()
        {
            IEnumerable<MyGarden> result = dbContext.Connection.Query<MyGarden>("GetMyGardern", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateMyGarden(MyGarden myGarden)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@common_name", myGarden.CommonName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@category", myGarden.Categories, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@origin_", myGarden.Origin, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@climate", myGarden.Climat, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@tempMax", myGarden.TemperatureMax, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@tempMin", myGarden.TemperatureMin, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@watering_", myGarden.Watering, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@color_", myGarden.Color, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@pot_diameter", myGarden.PotDiameter, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@_use", myGarden.Use_, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("CreateMyGarden", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateMyGarden(MyGarden myGarden)
        {
            var parameters = new DynamicParameters();
            parameters.Add("plant_id", myGarden.PlantId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("common_name", myGarden.CommonName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("category", myGarden.Categories, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("origin_", myGarden.Origin, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("climate", myGarden.Climat, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("tempMax", myGarden.TemperatureMax, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("tempMin", myGarden.TemperatureMin, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("watering_", myGarden.Watering, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("color_", myGarden.Color, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("pot_diameter", myGarden.PotDiameter, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("_use", myGarden.Use_, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("UpdateMyGarden", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool DeleteMyGarden(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@plant_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("DeleteMyGarden", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
