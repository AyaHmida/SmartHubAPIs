using DevAPI.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using SmartHomeHub.API.Dtos;
using SmartHomeHub.API.Entites;
using SmartHomeHub.API.Helpers.Interfaces;
using SmartHomeHub.API.Repositories.Interfaces;
using SmartHomeHub.API.Services.Interfaces;
using AppEmailSender = SmartHomeHub.API.Helpers.Interfaces.IEmailSender;


namespace SmartHomeHub.API.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;


        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly AppEmailSender _emailSender;

        public UserService(IUserRepository userRepository, 
            IPasswordHasher<User> passwordHasher, IUserRepository userRepo, 
            IJwtTokenGenerator tokenGenerator, AppEmailSender emailSender)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
            _emailSender = emailSender;


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
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role
            };

            await _userRepository.AddUserAsync(user);
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid credentials");

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

            if (!isPasswordValid)
                throw new UnauthorizedAccessException("Invalid credentials");

            var token = _tokenGenerator.GenerateToken(user);

            return new LoginResponseDTO
            {
                Token = token,
                Email = user.Email,
                Role = user.Role.ToString()
            };
        }

        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null) return false;

            var token = Guid.NewGuid().ToString();
            var expiry = DateTime.UtcNow.AddMinutes(30);

            await _userRepository.SaveResetTokenAsync(user.Id, token, expiry);

            var link = $"https://smarthomehub.com/reset-password?token={token}";
            var message = $"To reset your password, click the link below:\n{link}\nThis link will expire in 30 minutes.";

            await _emailSender.SendEmailAsync(email, "Reset Your Password", message);

            return true;
        }

        public async Task<bool> ResetPasswordAsync(string token, string newPassword)
        {
            var user = await _userRepository.GetByResetTokenAsync(token);
            if (user == null) return false;

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _userRepository.UpdatePasswordAsync(user.Id, passwordHash);

            return true;
        }
    }
}
