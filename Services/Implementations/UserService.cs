using DevAPI.DTOs;
using Microsoft.AspNetCore.Identity;
using SmartHomeHub.API.Dtos;
using SmartHomeHub.API.Entites;
using SmartHomeHub.API.Helpers.Interfaces;
using SmartHomeHub.API.Repositories.Interfaces;
using SmartHomeHub.API.Services.Interfaces;

namespace SmartHomeHub.API.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        private readonly IUserRepository _userRepo;
        private readonly IJwtTokenGenerator _tokenGenerator;
        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IUserRepository userRepo, IJwtTokenGenerator tokenGenerator)
        {
            _userRepo = userRepository;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator; 

        }
        public async Task RegisterAsync(UserRegisterDto dto)
        {
            bool emailExists = await _userRepository.EmailExistsAsync(dto.Email);
            if (emailExists)
            {
                throw new Exception("This email is already registered.");
            }

            // Convert DTO to User entity
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = _passwordHasher.HashPassword(null, dto.Password),
                Role = dto.Role
            };

            await _userRepository.AddUserAsync(user);
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request)
        {
            var user = await _userRepo.GetByEmailAsync(request.Email);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid credentials");

            var result = _passwordHasher.VerifyHashedPassword(null, user.PasswordHash, request.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new UnauthorizedAccessException("Invalid credentials");

            var token = _tokenGenerator.GenerateToken(user);

            return new LoginResponseDTO
            {
                Token = token,
                Email = user.Email,
                Role = user.Role.ToString()
            };
        }
    }
}
