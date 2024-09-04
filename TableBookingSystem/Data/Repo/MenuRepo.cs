using Microsoft.EntityFrameworkCore;
using TableBookingSystem.Data.Repo.IRepo;
using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;

namespace TableBookingSystem.Data.Repo
{
	public class MenuRepo : IMenuRepo
	{
		private readonly TableBookingSystemContext _context;
        public MenuRepo(TableBookingSystemContext context)
        {
			_context = context;
        }


		public async Task AddMenuItemAsync(MenuItem menuItem)
		{
			await _context.MenuItems.AddAsync(menuItem);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteMenuItemAsync(int menuItemId)
		{
			var menuItem = await _context.MenuItems.FindAsync(menuItemId);
			if (menuItem != null)
			{
				_context.MenuItems.Remove(menuItem);
			}
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
		{
			var menuItems = await _context.MenuItems.ToListAsync();
			return menuItems;
		}

		public async Task<MenuItem> GetMenuItemByIdAsync(int menuItemId)
		{
			var menuItem = await _context.MenuItems.FindAsync(menuItemId);
			return menuItem;
		}

		public async Task UpdateMenuItemAsync(MenuItem menuItem)
		{
			_context.MenuItems.Update(menuItem);
			await _context.SaveChangesAsync();
		}
	}
}
