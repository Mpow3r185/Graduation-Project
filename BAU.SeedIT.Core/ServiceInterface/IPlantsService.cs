using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bau.Seedit.Core.ServiceInterface
{
    public interface IPlantsService
    {
        List<Plants> GetPlants();
        bool addPlant(int profile_id, int plant_id);
        Plants GetPlantById(int id);
        List<Plants> SearchPlant(SearchPlantDTO plant);
    }
}
