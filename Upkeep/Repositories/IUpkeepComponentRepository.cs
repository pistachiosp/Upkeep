using System.Collections.Generic;
using Upkeep.Models;

namespace Upkeep.Repositories
{
    internal interface IUpkeepComponentRepository
    {
        List<UpkeepComponent> GetAllByProperty(int id);
        
    }
}