using System.ComponentModel.DataAnnotations;

namespace CustomerAPICrud.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(90)]
        [MinLength(3, ErrorMessage = "Name should be more than 3 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        [StringLength(150)]
        [MinLength(3, ErrorMessage = "Password should be more than 8 characters")]
        public string Password { get; set; } = string.Empty;
        [Required]
        [StringLength(90)]
        [MinLength(8, ErrorMessage = "Email should be more than 8 characters")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(15)]
        [MinLength(10, ErrorMessage = "Mobile should be 11 characters")]
        public string Mobile { get; set; } = string.Empty;
    }
}
