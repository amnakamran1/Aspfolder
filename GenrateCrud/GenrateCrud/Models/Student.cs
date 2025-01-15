using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenrateCrud.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // آٹو انکریمنٹ کے لیے
         // کالم کا نام ڈیٹا بیس م
        public int Id { get; set; }
        [Column("StdName",TypeName ="varchar(100)")]
        [Required]
        public string Name { get; set; }
        [Column("StdGender", TypeName = "varchar(100)")]
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]

        public string Address { get; set; }
    }
}
