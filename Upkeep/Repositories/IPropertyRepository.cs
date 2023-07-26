using System.Collections.Generic;
using Upkeep.Models;

namespace Upkeep.Repositories
{
    internal interface IPropertyRepository
    {
        List<Property> GetPropertiesById(int id);
    }
}