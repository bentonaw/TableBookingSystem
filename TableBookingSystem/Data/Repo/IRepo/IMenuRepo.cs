using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;

namespace TableBookingSystem.Data.Repo.IRepo
{
	public interface IMenuRepo
	{
		Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();
		Task<MenuItemDTO> GetMenuItemAsync(int menuItemId);
		Task AddMenuItemAsync(MenuItemDTO menuItemDTO);
		Task UpdateMenuItemAsync(int menuItemId);
		Task DeleteMenuItemAsync(int menuItemId);
	}
}
