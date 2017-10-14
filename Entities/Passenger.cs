// include for data annotations
using System.ComponentModel.DataAnnotations;

namespace app.Entities
{
    public class Passenger
    {
        // implicitly key, but manually specifying to be clear
        [Key]
        public int Id { get; set; }

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
