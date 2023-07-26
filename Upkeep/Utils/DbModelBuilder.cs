using Microsoft.Data.SqlClient;
using System.Collections.Generic;   
using Upkeep.Models;

namespace Upkeep.Utils
{
    public class DbModelBuilder
    {
        public static Property BuildPropertyModel(SqlDataReader reader)
        {
            // This is a helper method to build a property model from a SQL data reader
            return new Property()
            {
                Id = DbUtils.GetInt(reader, "PropertyId"),
                UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                PropertyName = DbUtils.GetString(reader, "PropertyName"),
                PropertyAddress = DbUtils.GetString(reader, "PropertyAddress"),
                PropertyImageUrl = DbUtils.GetString(reader, "PropertyImage"),               
            };
        } 
        public static UpkeepComponent BuildUpkeepComponentModel(SqlDataReader reader)
        {
            // This is a helper method to build a property model from a SQL data reader
            return new UpkeepComponent()
            {
                Id = DbUtils.GetInt(reader, "Id"),
                Name = DbUtils.GetString(reader, "Name"),
                UpkeepDetails = DbUtils.GetString(reader, "UpkeepDetails"),
                PropertyId = DbUtils.GetInt(reader, "PropertyId"),
                Frequency = DbUtils.GetInt(reader, "Frequency"),
                DueDate = DbUtils.GetInt(reader, "DueDate"),
            };
        }
    }
}
