using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using topcoderattempt1.Data;
using topcoderattempt1.Dtos;
using topcoderattempt1.Models;
using topcoderattempt1.Profiles;

namespace topcoderattempt1.Backend
{
    public class Authentication
    {
        private MercuryContext _context;
        private IMapper _mapper;

        public Authentication(MercuryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        
        }
        public static string generateUserHash(string password)
        {
            byte[] salt = new byte[0];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 1000,
                numBytesRequested: 24
                ));
            return hashed;
        }

        public static string generateEmailTokenHash()
        {

            var hashed = Guid.NewGuid().ToString();
            return hashed;
        }
        public string generateJwtToken(UserModel User)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.SecretKey));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.Sha512);
            var locations = User.UserLocations.Select(x=>x.LocationId).ToList();
            var permissions = User.UserLocations.OrderBy(x => x.LocationId).Select(x => (_mapper.Map<UserPermissionReadDto>(x.UserPermission))
                ).ToList();

            var claims = new[]
            {
                new Claim("ID", User.UserID.ToString()),
                new Claim("Name", User.Name),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, User.Email),
                new Claim("locationIds", System.Text.Json.JsonSerializer.Serialize(locations)),
                new Claim("permissions", System.Text.Json.JsonSerializer.Serialize(permissions)),
                new Claim("isLoggedIn", (!(User.IsTemporaryPassword ?? true)).ToString()),
                //new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                //new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };
            var token = new JwtSecurityToken(
                issuer: Constants.Issuer,
                audience: Constants.Audiance,
                claims: claims,
                signingCredentials: Constants.signingCredentials);
            var ret = new JwtSecurityTokenHandler().WriteToken(token);

            return ret;

        }

        public static string generateTempPassord()
        {
            byte[] salt = new byte[24];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            var tempPassword = Encoding.UTF8.GetString(salt);
            return tempPassword;
        }

    }
}
