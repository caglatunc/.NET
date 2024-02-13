using Microsoft.IdentityModel.Tokens;
using NTierArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Services;
public class TokenManager : ITokenService
{
    public string CreateToken(AppUser appUser)
    {
        string token = string.Empty;

        List<Claim> claims = new();
        claims.Add(new("UserId", appUser.Id.ToString()));
        claims.Add(new("Name", appUser.GetName() ?? string.Empty));
        claims.Add(new("Email", appUser.Email));
        claims.Add(new("UserName", appUser.UserName ?? string.Empty));

        JwtSecurityToken jwtSecurityToken = new(
                       issuer: "Cagla Tunc Savas",
                       audience: "School Application",
                       claims: claims,
                       expires: DateTime.Now.AddMinutes(30),
                       signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my secret key my secret key my secret key 1234...my secret key my secret key my secret key 1234...")), SecurityAlgorithms.HmacSha512));
       
        JwtSecurityTokenHandler tokenHandler = new();
        token= tokenHandler.WriteToken(jwtSecurityToken);

        return token;
    }

}
