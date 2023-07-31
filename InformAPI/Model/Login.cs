using System.ComponentModel.DataAnnotations;

namespace InformAPI.Model
{
    public class Login
    {
        public Guid Id { get; set; }
        [Required]
        public string User { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
