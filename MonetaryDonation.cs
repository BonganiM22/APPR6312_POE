using System.ComponentModel.DataAnnotations;
using APPR6312_ST10104738_POE.Models;


namespace APPR6312_ST10104738_POE.Models
{
    public class MonetaryDonation
    {
        [Key]
        public int MoneyId { get; set; }
        public string MoneyDonatorName { get; set; }
        public int Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime MoneyDonationDate { get; set; }
    }
}
