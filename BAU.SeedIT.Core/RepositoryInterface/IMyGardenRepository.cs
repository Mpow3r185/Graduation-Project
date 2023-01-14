using Bau.Seedit.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bau.Seedit.Core.RepositoryInterface
{
    public interface IMyGardenRepository
    {
        List<MyGarden> GetMyGarden();
        bool CreateMyGarden(MyGarden myGarden);
        bool UpdateMyGarden(MyGarden myGarden);
        bool DeleteMyGarden(int id);

    }
}
