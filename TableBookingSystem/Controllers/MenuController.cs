using Microsoft.AspNetCore.Mvc;
using TableBookingSystem.Models.DTOs;
using TableBookingSystem.Models.ViewModels;
using TableBookingSystem.Models;
using TableBookingSystem.Services.IService;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TableBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuController : ControllerBase
	{
		private readonly IMenuService _menuService;
		public MenuController(IMenuService menuService)
		{
			_menuService = menuService;
		}
		[HttpPost]
		public async Task<ActionResult> CreateMenuItem([FromBody] MenuItemDTO menuItemDTO)
		{
			try
			{
				await _menuService.AddMenuItemAsync(menuItemDTO);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}
		[HttpDelete("{menuItemId")]
		public async Task<ActionResult> DeleteMenuItem(int menuItemId)
		{
			try
			{
				await _menuService.DeleteMenuItemAsync(menuItemId);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}
		[HttpPatch("{menuItemId")]
		public async Task<ActionResult> UpdateMenuItem(int menuItemId, MenuItemDTO menuItemDTO)
		{
			try
			{
				await _menuService.UpdateMenuItemAsync(menuItemId, menuItemDTO);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<MenuItemViewModel>>> ViewAllMenuItems()
		{
			try
			{
				var listOfMenuItems = await _menuService.GetAllMenuItemsAsync();
				return Ok(listOfMenuItems);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}
		[HttpGet("{menuItemId")]
		public async Task<ActionResult<MenuItemViewModel>> GetMenuItemByIdAsync(int menuItemId)
		{
			try
			{
				var menuItem = await _menuService.GetMenuItemByIdAsync(menuItemId);
				return menuItem == null ? NotFound() : Ok(menuItem);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}
	}
}
