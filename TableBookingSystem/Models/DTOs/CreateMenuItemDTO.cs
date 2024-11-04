using System.ComponentModel.DataAnnotations;

namespace TableBookingSystem.Models.DTOs
{
	public class CreateMenuItemDTO
	{
		public string MenuItemName { get; set; }
		public string MenuItemCategory { get; set; }
        public string MenuDescription { get; set; }
        public double Price { get; set; }
		public int Quantity { get; set; }
        
    }
}
