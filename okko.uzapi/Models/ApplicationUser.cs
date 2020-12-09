using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace okko.uzapi.Models
{
    public class ApplicationUser : IdentityUser
    {     
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped] 
        [Display(Name = "Full Name")]
        public string FullName { get { return FirstName + " " + LastName; } }
    }

}
