using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.DTO;
using Bau.Seedit.Core.ServiceInterface;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bau.Seedit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly IPlantsService plantsService;
        public PlantsController(IPlantsService plantsService)
        {
            this.plantsService = plantsService;
        }
        [HttpGet]
        public List<Plants> GetPlants()
        {
            return plantsService.GetPlants();
        } 

        [HttpGet]
        [Route("getPlantById/{id}")]
        public Plants GetPlantsById(int id)
        {
            return plantsService.GetPlantById(id);
        }
        [HttpGet]
        [Route("SearchPlant")]
        public List<Plants> SearchPlant(SearchPlantDTO plant)
        {
            return plantsService.SearchPlant(plant);
        }


    }
}
