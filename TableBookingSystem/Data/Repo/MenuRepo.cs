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
			await SaveChangesAsync();
		}

        public async Task DeleteMenuItemAsync(int menuItemId)
		{
			var menuItem = await _context.MenuItems.FindAsync(menuItemId);
			if (menuItem != null)
			{
				_context.MenuItems.Remove(menuItem);
			}
			await SaveChangesAsync();
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
            await SaveChangesAsync();
        }

        //menu

        public async Task<IEnumerable<Menu>> GetAllMenusAsync()
        {
            return await _context.Menus
                .Include(m => m.MenuItems)
                .ToListAsync();
        }

        public async Task<Menu> GetMenuByIdAsync(int menuId)
        {
            return await _context.Menus
                .Include(m => m.MenuItems)
                .FirstOrDefaultAsync(m => m.MenuId == menuId);
        }

        public async Task AddItemToMenuAsync(Menu menu, int menuItemId)
        {
            var menuItem = await GetMenuItemByIdAsync(menuItemId);
            if (menuItem != null)
            {
                menu.MenuItems.Add(menuItem);
            }
            await SaveChangesAsync();
        }
        public async Task DeleteItemFromMenuAsync(Menu menu, int menuItemId)
        {
            var itemToRemove = await GetMenuItemByIdAsync(menuItemId);
            if (itemToRemove != null)
            {
                menu.MenuItems.Remove(itemToRemove);
            }
            await SaveChangesAsync();
        }

        public async Task AddMenuAsync(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Table> GetTableByIdAsync(int tableId)
        {
            return await _context.Tables
                .Include(t => t.TableId)
                .FirstOrDefaultAsync(t => t.TableId == tableId);
        }
    }
}
