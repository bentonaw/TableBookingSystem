using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;
using TableBookingSystem.Models.ViewModels;

namespace TableBookingSystem.Services.IService
{
	public interface IMenuService
	{
		Task<IEnumerable<MenuItemVM>> GetAllMenuItemsAsync();
		Task<MenuItemVM> GetMenuItemByIdAsync(int menuItemId);
		Task AddMenuItemAsync(CreateMenuItemDTO menuItemDTO);
		Task UpdateMenuItemAsync(int menuItemId, CreateMenuItemDTO menuItem);
		Task DeleteMenuItemAsync(int menuItemId);

	}
}
