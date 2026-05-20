using VidyaSar.Application.DTOs;
using VidyaSar.Domain.Entities;

namespace VidyaSar.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(UserProfile user);
    LoggedInUserDto? GetLoggedInUser(string token);
    long GetExpirationTime();
}
