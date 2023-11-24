using System.ComponentModel.DataAnnotations;

namespace APPR6312_ST10104738_POE.Models
{
    public class AuthorizedUser
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
