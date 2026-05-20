using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VidyaSar.Application.DTOs;
using VidyaSar.Application.Interfaces;
using VidyaSar.Domain.Entities;

namespace VidyaSar.Infrastructure.Security;

public class JwtService : IJwtService
{
    private const long ExpirationMs = 1000L * 60 * 60 * 24; // 24 hours

    private readonly string _secret;
    private readonly SymmetricSecurityKey _key;

    public JwtService(IConfiguration config)
    {
        _secret = config["Jwt:Secret"]
            ?? throw new InvalidOperationException("Jwt:Secret is not configured.");
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
    }

    public string GenerateToken(UserProfile user)
    {
        var claims = new List<Claim>
        {
            new("userid",    user.Userid),
            new("role",      user.Role?.ToString()    ?? ""),
            new("name",      user.Name               ?? ""),
            new("cl_col_id", user.ClColId?.ToString() ?? ""),
            new("branchId",  user.BranchId?.ToString() ?? ""),
            new("email",     user.Emailid            ?? ""),
            new("mob_no",    user.MobNo?.ToString()   ?? ""),
            new("telNo",     user.Telno              ?? ""),
            new("status",    user.Active?.ToString()  ?? ""),
            new(JwtRegisteredClaimNames.Sub, user.Userid),
            new(JwtRegisteredClaimNames.Iat,
                DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
                ClaimValueTypes.Integer64)
        };

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims:   claims,
            expires:  DateTime.UtcNow.AddMilliseconds(ExpirationMs),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public LoggedInUserDto? GetLoggedInUser(string token)
    {
        try
        {
            var handler    = new JwtSecurityTokenHandler();
            var parameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey         = _key,
                ValidateIssuer           = false,
                ValidateAudience         = false,
                ClockSkew                = TimeSpan.Zero
            };

            var principal = handler.ValidateToken(token, parameters, out _);

            return new LoggedInUserDto
            {
                Userid    = principal.FindFirstValue("userid") ?? "",
                Name      = principal.FindFirstValue("name"),
                Role      = int.TryParse(principal.FindFirstValue("role"), out var r) ? r : null,
                CollegeId = long.TryParse(principal.FindFirstValue("cl_col_id"), out var c) ? c : null,
                BranchId  = long.TryParse(principal.FindFirstValue("branchId"), out var b) ? b : null
            };
        }
        catch
        {
            return null;
        }
    }

    public long GetExpirationTime() =>
        DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + ExpirationMs;
}
