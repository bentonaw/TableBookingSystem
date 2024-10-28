using AutoMapper;
using TableBookingSystem.Data.Repo.IRepo;
using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;
using TableBookingSystem.Services.IService;

namespace TableBookingSystem.Services
{
    public class MenuService : IMenuService
	{
		private readonly IMenuRepo _menuRepo;
		private readonly IMapper _mapper;
        public MenuService(IMenuRepo menuRepo, IMapper mapper)
        {
			_menuRepo = menuRepo;
			_mapper = mapper;
        }

		public async Task AddMenuItemAsync(CreateMenuItemDTO menuItem)
		{
			var newMenuItem = _mapper.Map<MenuItem>(menuItem);
			await _menuRepo.AddMenuItemAsync(newMenuItem);
		}

		public async Task DeleteMenuItemAsync(int menuItemId)
		{
			var menuItem = await _menuRepo.GetMenuItemByIdAsync(menuItemId);
			if (menuItem != null)
			{
				await _menuRepo.DeleteMenuItemAsync(menuItemId);
			}
		}
		
		public async Task UpdateMenuItemAsync(int menuItemId, CreateMenuItemDTO menuItemDTO)
		{
			var menuItem = await _menuRepo.GetMenuItemByIdAsync(menuItemId);
			if (!string.IsNullOrEmpty(menuItemDTO.MenuItemName))
			{
				menuItem.MenuItemName = menuItemDTO.MenuItemName;
			}
			if (!string.IsNullOrEmpty(menuItemDTO.MenuItemCategory))
			{
				menuItem.MenuItemCategory = menuItemDTO.MenuItemCategory;
			}
			if (!double.IsNaN(menuItemDTO.Price))
			{
				menuItem.Price = menuItemDTO.Price;
			}
			if (int.IsPositive(menuItemDTO.Quantity))
			{
				menuItem.Quantity = menuItemDTO.Quantity;
			}
		}

		public async Task<IEnumerable<GetMenuItemDTO>> GetAllMenuItemsAsync()
		{
			var menuItemList = await _menuRepo.GetAllMenuItemsAsync();
			return _mapper.Map<IEnumerable<GetMenuItemDTO>>(menuItemList);
		}

		public async Task<GetMenuItemDTO> GetMenuItemByIdAsync(int menuItemId)
		{
			var menuItem = await _menuRepo.GetMenuItemByIdAsync(menuItemId);
			return menuItem != null ? _mapper.Map<GetMenuItemDTO>(menuItem) : null;
		}

		// menu
        
        public async Task<IEnumerable<GetMenuDTO>> GetAllMenusAsync()
        {
            var menus = await _menuRepo.GetAllMenusAsync();
            return _mapper.Map<IEnumerable<GetMenuDTO>>(menus);
        }

        public async Task<GetMenuDTO> GetMenuByIdAsync(int menuId)
        {
            var menu = await _menuRepo.GetMenuByIdAsync(menuId);
            return menu != null ? _mapper.Map<GetMenuDTO>(menu) : null;
        }
        public async Task AddItemToMenuAsync(int menuId, int menuItemId)
        {
            var menu = await _menuRepo.GetMenuByIdAsync(menuId);
            if (menu != null)
            {
                var menuItem = await _menuRepo.GetMenuItemByIdAsync(menuItemId);
                if (menuItem != null)
                {
                    await _menuRepo.AddItemToMenuAsync(menu, menuItemId);
                }
                else
                {
                    throw new ArgumentException("Menu already contains this menu item");
                }
            }
            else
            {
                throw new ArgumentException("Menu not found");
            }
        }
        public async Task DeleteItemFromMenuAsync(int menuId, int menuItemId)
        {
            var menu = await _menuRepo.GetMenuByIdAsync(menuId);
            if (menu != null)
            {
                var menuItemToRemove = await _menuRepo.GetMenuItemByIdAsync(menuItemId);
                if (menuItemToRemove != null)
                {
					await _menuRepo.DeleteItemFromMenuAsync(menu, menuItemId);
                }
                else
                {
                    throw new ArgumentException("Menu item not found");
                }
            }
            else
            {
                throw new ArgumentException("Menu not found");
            }
        }

        public async Task CreateMenuAsync(CreateMenuDTO menuDTO)
        {
            var newMenu = _mapper.Map<Menu>(menuDTO);
            await _menuRepo.AddMenuAsync(newMenu);
        }
    }
}
