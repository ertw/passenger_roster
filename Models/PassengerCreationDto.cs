// include for data annotations
using System.ComponentModel.DataAnnotations;
namespace app.Models
{
    public class PassengerCreationDto
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }
    }
}
