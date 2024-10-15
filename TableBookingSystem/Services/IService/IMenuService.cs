using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;

namespace TableBookingSystem.Services.IService
{
    public interface IMenuService
	{
		Task<IEnumerable<GetMenuItemDTO>> GetAllMenuItemsAsync();
		Task<GetMenuItemDTO> GetMenuItemByIdAsync(int menuItemId);
		Task AddMenuItemAsync(CreateMenuItemDTO menuItemDTO);
		Task UpdateMenuItemAsync(int menuItemId, CreateMenuItemDTO menuItem);
		Task DeleteMenuItemAsync(int menuItemId);

        // menu
        Task AddItemToMenuAsync(int menuId, int menuItemId);
		Task<IEnumerable<GetMenuDTO>> GetAllMenusAsync();
		Task<GetMenuDTO> GetMenuByIdAsync(int menuId);
		Task DeleteItemFromMenuAsync(int menuId, int menuItemId);
		Task CreateMenuAsync(CreateMenuDTO createMenuDTO);
	}
}
