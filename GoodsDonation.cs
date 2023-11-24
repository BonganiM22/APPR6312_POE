using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;

namespace APPR6312_ST10104738_POE.Models
{
    public class GoodsDonation
    {
        [Key]
        public int GoodsId { get; set; }
        public string DonatorName { get; set; }
        [DataType(DataType.Date)]
        public DateTime GoodsDonationDate { get; set; }
        public string GoodsCategory { get; set; }
        public int GoodsQuantity { get; set; }
        public string GoodsDescription { get; set; }
    }
}
