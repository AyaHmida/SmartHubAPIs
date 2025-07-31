using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHomeHub.API.Dtos;
using SmartHomeHub.API.Services.Interfaces;

namespace SmartHomeHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly IHousesService _housesService;
        public HousesController(IHousesService housesService)
        {
            _housesService = housesService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateHouse([FromBody] CreateHouseDto dto)
        {
            var house = await _housesService.CreateHouseAsync(dto);
            return Ok(house);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var houses = await _housesService.GetAllAsync();
            return Ok(houses);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _housesService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var house = await _housesService.GetByIdAsync(id);
            if (house == null) return NotFound();
            return Ok(house);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, UpdateHouseDto dto)
        {
            var updatedHouse = await _housesService.UpdateAsync(id, dto);
            if (updatedHouse == null) return NotFound();
            return Ok(updatedHouse);
        }

    }
}
