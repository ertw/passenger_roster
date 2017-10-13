// include for data annotations
using System.ComponentModel.DataAnnotations;
namespace app.Models
{
    public class PassengerCreationDto
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
