using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;

namespace TableBookingSystem.Data.Repo.IRepo
{
	public interface IMenuRepo
	{
		Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();
		Task<MenuItem> GetMenuItemByIdAsync(int menuItemId);
		Task AddMenuItemAsync(MenuItem menuItem);
		Task UpdateMenuItemAsync(MenuItem menuItem);
		Task DeleteMenuItemAsync(int menuItemId);
	}
}
