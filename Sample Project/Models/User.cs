using System.ComponentModel.DataAnnotations;

namespace Sample_Project.Models
{
    public class User
    {
        [Key]
        public int UId { get; set; } 

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

    }
}
