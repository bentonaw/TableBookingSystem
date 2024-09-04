using AutoMapper;
using TableBookingSystem.Data.Repo.IRepo;
using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;
using TableBookingSystem.Models.ViewModels;
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

		public async Task AddMenuItemAsync(MenuItemDTO menuItem)
		{
			var newMenuItem = _mapper.Map<MenuItem>(menuItem);
			await _menuRepo.AddMenuItemAsync(newMenuItem);
		}

		public async Task DeleteMenuItemAsync(int menuItemId)
		{
			var menuItem = await _menuRepo.GetMenuItemByIdAsync(menuItemId);
			if (menuItem != null)
			{
				_menuRepo.DeleteMenuItemAsync(menuItemId);
			}
		}
		
		public async Task UpdateMenuItemAsync(int menuItemId, MenuItemDTO menuItemDTO)
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
			if (!string.IsNullOrEmpty(menuItemDTO.MenuItemType))
			{
				menuItem.MenuItemType = menuItemDTO.MenuItemType;
			}
			if (!double.IsNaN(menuItemDTO.Price))
			{
				menuItem.Price = menuItemDTO.Price;
			}
			if (!string.IsNullOrEmpty(menuItemDTO.AllergyCaution))
			{
				menuItem.AllergyCaution = menuItemDTO.AllergyCaution;
			}
			if (int.IsPositive(menuItemDTO.Quantity))
			{
				menuItem.Quantity = menuItemDTO.Quantity;
			}
		}

		public async Task<IEnumerable<MenuItemViewModel>> GetAllMenuItemsAsync()
		{
			var menuItemList = await _menuRepo.GetAllMenuItemsAsync();
			return _mapper.Map<IEnumerable<MenuItemViewModel>>(menuItemList);
		}

		public async Task<MenuItemViewModel> GetMenuItemByIdAsync(int menuItemId)
		{
			var menuItem = await _menuRepo.GetMenuItemByIdAsync(menuItemId);
			return menuItem != null ? _mapper.Map<MenuItemViewModel>(menuItem) : null;
		}
	}
}
