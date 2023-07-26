using System.ComponentModel.DataAnnotations;

namespace Upkeep.Models
{
    public class UpkeepComponent
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string UpkeepDetails { get; set; }
        public int PropertyId { get; set; }
        //public string UpkeepItem { get; set; }
        public int Frequency { get; set; }
        public int DueDate { get; set; }
    }
}
