using System.ComponentModel.DataAnnotations;

namespace TableBookingSystem.Models.DTOs
{
	public class CreateMenuItemDTO
	{
		public string MenuItemName { get; set; }
		public string MenuItemCategory { get; set; }
		public string MenuItemType { get; set; }
		public double Price { get; set; }
		public string AllergyCaution { get; set; }
		public int Quantity { get; set; }
	}
}
