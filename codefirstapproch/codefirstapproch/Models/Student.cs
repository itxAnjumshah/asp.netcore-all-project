
using System.ComponentModel.DataAnnotations;

namespace codefirstapproch.Models
{
    public class Student
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string gender { get; set; }
         
        [Required] 
        public DateOnly Dob { get; set; }

        [Required] 
        public int age { get; set; } 

    }
}
