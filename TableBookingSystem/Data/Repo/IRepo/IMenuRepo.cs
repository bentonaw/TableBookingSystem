using Microsoft.EntityFrameworkCore;
using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;

namespace TableBookingSystem.Data.Repo.IRepo
{
	public interface IMenuRepo
	{
		//Menu item
		Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();
		Task<MenuItem> GetMenuItemByIdAsync(int menuItemId);
		Task AddMenuItemAsync(MenuItem menuItem);
		Task UpdateMenuItemAsync(MenuItem menuItem);
		Task DeleteMenuItemAsync(int menuItemId);

		//Menu
		Task AddMenuAsync(Menu menu);
		Task<IEnumerable<Menu>> GetAllMenusAsync();
		Task<Menu> GetMenuByIdAsync(int menuId);
		Task AddItemToMenuAsync(Menu menu, int menuItemId);
		Task DeleteItemFromMenuAsync(Menu menu, int menuItemId);

		Task SaveChangesAsync();
    }
}
