﻿using DevAPI.DTOs;
using SmartHomeHub.API.Dtos;

namespace SmartHomeHub.API.Services.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(UserRegisterDto dto);
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request);


    }
}
