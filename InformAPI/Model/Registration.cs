using System.ComponentModel.DataAnnotations;

namespace InformAPI.Model
{
    public class Registration
    {
        public Guid Id { get; set; }
        [Required]
        public string User { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Password { get; set; }


    }

}
