using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace TableBookingSystem.Models
{
	public class Customer
	{
        [Key]
        public int CustomerId { get; set; }
        [Required]
		[StringLength(30), MinLength(2)]
		public string FirstName { get; set; }
		[Required]
		[StringLength(50), MinLength(2)]
		public string LastName { get; set; }
		[EmailAddress]
		public string Email { get; set; }
		[Phone]
        public string PhoneNumber { get; set; }
    }
}
