using System.ComponentModel.DataAnnotations;

namespace TableBookingSystem.Models
{
	public class MenuItem
	{
        [Key]
        public int MenuItemId { get; set; }
		[Required]
		[StringLength(50), MinLength(2)]
		public string MenuItemName { get; set; }
		[Required]
		[StringLength(30), MinLength(2)]
		public string MenuItemCategory { get; set; }
		[Required]
		[StringLength(30), MinLength(2)]
		public string MenuItemType { get; set; }
		public string MenuDescription { get; set; }
		public double Price { get; set; }
		[StringLength(50), MinLength(2)]
		public string AllergyCaution { get; set; }
        public int Quantity { get; set; }

    }
}
