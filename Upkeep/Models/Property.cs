using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Upkeep.Models
{
    public class Property
    {
        public int Id { get; set; }
        [StringLength(28, MinimumLength = 28)]
        public int UserProfileId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PropertyName { get; set; }

        [Required]
        [MaxLength(200)]
        public string PropertyAddress { get; set; }
        [DataType(DataType.Url)]
        [MaxLength(255)]
        public string PropertyImageUrl { get; set; }
        public List<UpkeepComponent> Components { get; set; }
    }
}
