using System.ComponentModel.DataAnnotations;

namespace okko.uzapi.DTOs
{
    public class UserDtd
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 6) ]
        public string Password { get; set; }
    }
}
