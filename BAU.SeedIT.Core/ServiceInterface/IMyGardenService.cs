using Bau.Seedit.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bau.Seedit.Core.ServiceInterface
{
    public interface IMyGardenService
    {
        List<MyGarden> GetMyGardens();
        bool CreateMyGarden(MyGarden myGarden);
        bool UpdateMyGarden(MyGarden myGarden);
        bool DeleteMyGarden(int id);
    }
}
