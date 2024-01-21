using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Application.Contracts.Identity;
using Restaurant.Application.Models;
using Restaurant.Domain.Constants;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Restaurant.Persistence.Services.Identity;

public class JwtService(IOptionsMonitor<SiteSettings> options,IApplicationSignInManager signInManager) : IJwtService
{
    private readonly JwtConfigs _jwtConfigs = options.CurrentValue.JwtConfigs;
    private readonly IApplicationSignInManager _signInManager = signInManager;

    public async Task<string> Generate(User user)
    {
        var secretKey = Encoding.UTF8.GetBytes(_jwtConfigs.SecretKey);
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey),SecurityAlgorithms.HmacSha256Signature);

        var claims = await GetClaims(user);
        var tokenOptions = new JwtSecurityToken(
            _jwtConfigs.Issuer,
            _jwtConfigs.Audience,
            claims,
            DateTime.Now.AddMinutes(_jwtConfigs.NotBeforeMinutes),
            DateTime.Now.AddMinutes(_jwtConfigs.ExpirationMinutes),
            signingCredentials);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return token;
    }

    private async Task<IEnumerable<Claim>> GetClaims(User user)
    {
        var result = await _signInManager.ClaimsFactory.CreateAsync(user);
        var claims = new List<Claim>(result.Claims)
        {
            new(ClaimNames.Avatar,user.Avatar),
        };
        return claims;
    }
}