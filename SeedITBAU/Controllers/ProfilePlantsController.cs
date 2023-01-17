using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.ServiceInterface;
using BAU.SeedIT.Core.Data;
using BAU.SeedIT.Core.DTO;
using BAU.SeedIT.Core.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAU.SeedIT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilePlantsController : ControllerBase
    {
        private readonly IProfilePlantsService profilePlantsService;
        private readonly IAccountService accountService;
        GetPlantDTO profilePlants1 = new GetPlantDTO();

        public ProfilePlantsController(IProfilePlantsService _profilePlantsService, IAccountService _accountService)
        {
            profilePlantsService = _profilePlantsService;
            accountService = _accountService;
        }
        [HttpGet]
        [Route("getPlantById/{id}")]
        public Plants GetPlantsById(int id)
        {
            return profilePlantsService.GetPlantById(id);
        }
        [HttpPost]
        [Route("AddPlant")]
        public IActionResult AddPlant(ProfilePlants profilePlants)
        {
            profilePlants.id = Guid.NewGuid().GetHashCode();
            profilePlantsService.AddPlant(profilePlants.profileId, profilePlants.plantId);
            profilePlants1.Profile = accountService.getProfileById(profilePlants.profileId);
            profilePlants1.Plant = profilePlantsService.GetPlantById(profilePlants.plantId);
            return Ok(profilePlants1);

        }

    }
}