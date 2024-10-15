using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableBookingSystem.Models
{
	public class Menu
	{
        [Key]
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }

    }
}
