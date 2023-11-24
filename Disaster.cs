using System.ComponentModel.DataAnnotations;

namespace APPR6312_ST10104738_POE.Models
{
    public class Disaster
    {
        [Key]
        public int DisasterId { get; set; }
        public string DisasterName { get; set; }
        public string DisasterDescription { get; set; }
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string AidType { get; set; }
    }
}
