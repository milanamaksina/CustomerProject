using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace CustomerProject
{
    public abstract class Person
    {
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
    }
}