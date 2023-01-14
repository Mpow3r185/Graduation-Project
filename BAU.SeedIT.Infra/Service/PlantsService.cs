using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.DTO;
using Bau.Seedit.Core.RepositoryInterface;
using Bau.Seedit.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bau.Seedit.Infra.Service
{
    public class PlantsService : IPlantsService
    {
        private readonly IPlantsRepository plantsRepository;

        public PlantsService(IPlantsRepository plantsRepository)
        {
            this.plantsRepository = plantsRepository;
        }
        public bool addPlant(int profile_id, int plant_id)
        {
            return plantsRepository.addPlant(profile_id, plant_id);
        }

        public List<Plants> GetPlants()
        {
            return plantsRepository.GetPlants();
        }
    
        public Plants GetPlantById(int id)
        {
            return plantsRepository.GetPlantById(id);
        }
        public List<Plants> SearchPlant(SearchPlantDTO plant)
        {
            return plantsRepository.SearchPlant(plant);
        }
    }
}
