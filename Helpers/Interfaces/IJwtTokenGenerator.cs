using SmartHomeHub.API.Entites;

namespace SmartHomeHub.API.Helpers.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);

    }
}
