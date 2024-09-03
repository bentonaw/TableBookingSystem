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


		public Task AddMenuItemAsync(MenuItemDTO )
		{
			throw new NotImplementedException();
		}

		public Task DeleteMenuItemAsync(int customerId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
		{
			throw new NotImplementedException();
		}

		public Task<MenuItemDTO> GetMenuItemAsync(int menuItemId)
		{
			throw new NotImplementedException();
		}

		public Task UpdateMenuItemAsync(int menuItemId)
		{
			throw new NotImplementedException();
		}
	}
}
