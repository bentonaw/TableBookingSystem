namespace TableBookingSystem.Models.DTOs
{
    public class GetMenuDTO
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
