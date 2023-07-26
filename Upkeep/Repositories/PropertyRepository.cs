using Upkeep.Models;
using Upkeep.Repositories;
using Upkeep.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Upkeep.Repositories
{
    public class PropertyRepository : BaseRepository, IPropertyRepository
    {
        public PropertyRepository(IConfiguration configuration) : base(configuration) { }
        
        public List<Property> GetPropertiesById(int id)
        {
            using (var conn = Connection)
            {                 
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select p.Id, p.PropertyName, p.PropertyAddress, p.PropertyImagUrl AS PropertyImage, u.Id AS UpkeepId, u.Name AS UpkeepName, u.UpkeepDetails, u.PropertyId, u.Frequency" +
                        "From Property p" +
                        "LEFT JOIN UpkeepComponent u ON u.PropertyId = p.Id" +
                        "WHERE UserProfileId = @ Id";
                    DbUtils.AddParameter(cmd, "@Id", id);
                    var reader = cmd.ExecuteReader();
                    var properties = new List<Property>();

                    while (reader.Read())
                    {
                        var propertyId = DbUtils.GetInt(reader, "PropertyId");
                        var existingProperty = properties.FirstOrDefault(p => p.Id == propertyId);
                        if (existingProperty == null)
                        {
                            existingProperty = DbModelBuilder.BuildPropertyModel(reader);
                            properties.Add(existingProperty);
                        }
                        if (DbUtils.IsNotDbNull(reader, "UpkeepId"))
                        {
                            existingProperty.Components.Add(DbModelBuilder.BuildUpkeepComponentModel(reader));
                        }
                    }
                    reader.Close();
                    return properties;
                }
                
            }
        }
        public void AddProperty(Property property)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Property (UserProfileId, PropertyName, PropertyAddress, PropertyImageUrl)
                        OUTPUT INSERTED.ID
                        VALUES (@UserProfileId, @PropertyName, @PropertyAddress, @PropertyImageUrl)";
                    DbUtils.AddParameter(cmd, "@UserProfileId", property.UserProfileId);
                    DbUtils.AddParameter(cmd, "@PropertyName", property.PropertyName);
                    DbUtils.AddParameter(cmd, "@PropertyAddress", property.PropertyAddress);
                    DbUtils.AddParameter(cmd, "@PropertyImageUrl", property.PropertyImageUrl);
                    property.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
        public void UpdateProperty(Property property)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        @"UPDATE Property
                            SET PropertyName = @PropertyName,
                                PropertyAddress = @PropertyAddress,
                                PropertyImageUrl = @PropertyImageUrl
                            WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@PropertyName", property.PropertyName);
                    DbUtils.AddParameter(cmd, "@PropertyAddress", property.PropertyAddress);
                    DbUtils.AddParameter(cmd, "@PropertyImageUrl", property.PropertyImageUrl);
                    DbUtils.AddParameter(cmd, "@Id", property.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteProject(int propertyId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        @"DELETE FROM Property
                            WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@Id", propertyId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
