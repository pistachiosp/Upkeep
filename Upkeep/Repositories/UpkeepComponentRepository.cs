using System.Collections.Generic;
using Upkeep.Models;
using Upkeep.Utils;
using Microsoft.Extensions.Configuration;

namespace Upkeep.Repositories
{
    public class UpkeepRepository : BaseRepository, IUpkeepComponentRepository
    {
        public UpkeepRepository(IConfiguration configuration) : base(configuration) { }
        public List<UpkeepComponent> GetUpkeepByProperty(int id)
        {

        }
    }
}
