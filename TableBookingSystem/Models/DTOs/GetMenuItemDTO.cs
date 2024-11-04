namespace TableBookingSystem.Models.DTOs
{
    public class GetMenuItemDTO
    {
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemCategory { get; set; }
        public string MenuDescription { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool Available => Quantity > 0;
    }
}
