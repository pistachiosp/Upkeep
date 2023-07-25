using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Upkeep.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        [StringLength(28, MinimumLength = 28)]
        public string FirebaseUserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

    }
}