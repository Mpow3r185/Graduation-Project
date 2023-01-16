using Bau.Seedit.Core.Data;
using BAU.SeedIT.Core.Data;
using BAU.SeedIT.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAU.SeedIT.Core.ServiceInterface
{
    public interface IProfilePlantsService
    {
        public Plants AddPlant(int profileId, int plantId);
        public Plants GetPlantById(int id);
        public List<Plants> getPlantsByProfileId(int id);
    }
}
