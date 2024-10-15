using Microsoft.AspNetCore.Mvc;
using TableBookingSystem.Models.DTOs;
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

        // Menu Items
        [HttpPost("menu-items")]
        public async Task<ActionResult> CreateMenuItem([FromBody] CreateMenuItemDTO menuItemDTO)
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
        [HttpDelete("menu-items/{menuItemId}")]
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
        [HttpPatch("menu-items/{menuItemId}")]
        public async Task<ActionResult> UpdateMenuItem(int menuItemId, CreateMenuItemDTO menuItemDTO)
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
        [HttpGet("menu-items")]
        public async Task<ActionResult<IEnumerable<GetMenuItemDTO>>> ViewAllMenuItems()
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
        [HttpGet("menu-items/{menuItemId}")]
        public async Task<ActionResult<GetMenuItemDTO>> GetMenuItemByIdAsync(int menuItemId)
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

        // Menu
        [HttpPost("menus")]
        public async Task<ActionResult> CreateMenu([FromBody] CreateMenuDTO menuDTO)
        {
            try
            {
                await _menuService.CreateMenuAsync(menuDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPost("menus/{menuId}/menu-items/{menuItemId}")]
        public async Task<ActionResult> AddMenuItemToMenu(int menuId, int menuItemId)
        {
            try
            {
                await _menuService.AddItemToMenuAsync(menuId, menuItemId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpDelete("menus/{menuId}/menu-items/{menuItemId}")]
        public async Task<ActionResult> DeleteMenuItemFromMenu(int menuId, int menuItemId)
        {
            try
            {
                await _menuService.DeleteItemFromMenuAsync(menuId, menuItemId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("menus")]
        public async Task<ActionResult<IEnumerable<GetMenuDTO>>> ViewAllMenusAsync(CreateMenuDTO menuDTO)
        {
            try
            {
                var listOfMenus = await _menuService.GetAllMenusAsync();
                return Ok(listOfMenus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("menus/{menuId}")]
        public async Task<ActionResult<GetMenuDTO>> ViewMenuByIdAsync(int menuId)
        {
            try
            {
                var menu = await _menuService.GetMenuByIdAsync(menuId);
                return menu == null ? NotFound() : Ok(menu);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
