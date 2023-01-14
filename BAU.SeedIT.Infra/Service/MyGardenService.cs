using Bau.Seedit.Core.Data;
using Bau.Seedit.Core.RepositoryInterface;
using Bau.Seedit.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bau.Seedit.Infra.Service
{
    public class MyGardenService : IMyGardenService
    {
        private readonly IMyGardenRepository myGardenRepository;

        public MyGardenService(IMyGardenRepository _myGardenRepository)
        {
            myGardenRepository = _myGardenRepository;
        }

        public List<MyGarden> GetMyGardens()
        {
            return myGardenRepository.GetMyGarden();
        }
        public bool CreateMyGarden(MyGarden myGarden)
        {
            return myGardenRepository.CreateMyGarden(myGarden);
        }
        public bool UpdateMyGarden(MyGarden myGarden)
        {
            return myGardenRepository.UpdateMyGarden(myGarden);
        }
        public bool DeleteMyGarden(int id)
        {
            return myGardenRepository.DeleteMyGarden(id);
        }

    }
}
