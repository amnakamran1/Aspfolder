

using System.ComponentModel.DataAnnotations;

namespace ViewCRUD.Models
{
    public class Study
    {
        
        
            public int Id { get; set; }
        [Required]
            public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
            public string Faculty { get; set; }
    }
}
