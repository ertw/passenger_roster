// DTO for adding a new passenger

// include for data annotations
using System.ComponentModel.DataAnnotations;

namespace app.Models
{
    public class PassengerCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }
    }
}
