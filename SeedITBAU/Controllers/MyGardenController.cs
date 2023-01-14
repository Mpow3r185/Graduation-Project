using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.ServiceInterface;
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
    public class MyGardenController : ControllerBase
    {
        private readonly IMyGardenService myGardenService;
        public MyGardenController(IMyGardenService _myGardenService)
        {
            myGardenService = _myGardenService;
        }

        [HttpGet]   
        public List<MyGarden> GetMyGardens()
        {
            return myGardenService.GetMyGardens();
        }
        [HttpPost]
        public bool CreateMyGarden(MyGarden myGarden)
        {
            return myGardenService.CreateMyGarden(myGarden);
        }
        [HttpPut]
        public bool UpdateMyGarden(MyGarden myGarden)
        {
            return myGardenService.UpdateMyGarden(myGarden);
        }
        [HttpDelete]
        [Route("DeleteMyGarden/{id}")]
        public bool DeleteMyGarden(int id)
        {
            return myGardenService.DeleteMyGarden(id);
        }
    }
}
