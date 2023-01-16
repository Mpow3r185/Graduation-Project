using Bau.Seedit.Core.Data;
using BAU.SeedIT.Core.Data;
using BAU.SeedIT.Core.DTO;
using BAU.SeedIT.Core.RepositoryInterface;
using BAU.SeedIT.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAU.SeedIT.Infra.Service
{
    public class ProfilePlantsService : IProfilePlantsService
    {
        private readonly IProfilePlantsRepository profilePlantsRepository;

        public ProfilePlantsService(IProfilePlantsRepository _profilePlantsRepository)
        {
            profilePlantsRepository = _profilePlantsRepository;
        }
        public Plants AddPlant(int profileId, int plantId)
        {
            return profilePlantsRepository.AddPlant(profileId, plantId);
        }

        public Plants GetPlantById(int id)
        {
            return profilePlantsRepository.GetPlantById(id);
        }
        public List<Plants> getPlantsByProfileId(int id)
        {
            return profilePlantsRepository.getPlantsByProfileId(id);
        }
    }
}
