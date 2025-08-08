using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHomeHub.API.Dtos;
using SmartHomeHub.API.Entites;
using SmartHomeHub.API.Services.Implementations;
using SmartHomeHub.API.Services.Interfaces;

namespace SmartHomeHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _Deviceservice;

        public DeviceController(IDeviceService service)
        {
            _Deviceservice = service;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] DeviceCreateDto dto)
        {
            await _Deviceservice.CreateDevice(dto);
            return Ok("Device created.");
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAll()
        {
            var devices = await _Deviceservice.GetAllDevices();
            return Ok(devices);

        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetById(int id)
        {
            var device = await _Deviceservice.GetDeviceById(id);
            if (device == null) return NotFound();
            return Ok(device);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _Deviceservice.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

    }
}
