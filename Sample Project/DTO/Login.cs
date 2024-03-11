using System.ComponentModel.DataAnnotations;

namespace Sample_Project.DTO
{
    public class Login
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
