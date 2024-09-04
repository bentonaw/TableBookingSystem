using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;
using TableBookingSystem.Models.ViewModels;

namespace TableBookingSystem.Services.IService
{
	public interface IMenuService
	{
		Task<IEnumerable<MenuItemViewModel>> GetAllMenuItemsAsync();
		Task<MenuItemViewModel> GetMenuItemByIdAsync(int menuItemId);
		Task AddMenuItemAsync(MenuItemDTO menuItemDTO);
		Task UpdateMenuItemAsync(int menuItemId, MenuItemDTO menuItem);
		Task DeleteMenuItemAsync(int menuItemId);

	}
}
