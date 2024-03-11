using System.ComponentModel.DataAnnotations;

namespace Sample_Project.Models
{
    public class Blog
    {
        [Key]
        public int BId { get; set; }

        public string Title { get; set; }
        public string Descripition { get; set; }

        public  string BAuthor {  get; set; }
    }
}
