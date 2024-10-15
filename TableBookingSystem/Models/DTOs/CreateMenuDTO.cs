namespace TableBookingSystem.Models.DTOs
{
    public class CreateMenuDTO
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
