using System;
using System.Collections.Generic;

using System.Linq;

using System.Security.Cryptography.X509Certificates;
using System.Text;
using topcoderattempt1.Backend;
using topcoderattempt1.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AutoMapper;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Threading.Tasks;

namespace topcoderattempt1.Data
{
    public class SqlUserRepo : IUserRepo
    {
        private MercuryContext _context;
        private IMapper _mapper;

        public SqlUserRepo(MercuryContext context, IMapper map)
        {
            _context = context;
            _mapper = map;
        }
        public bool ChangeEmailRequest(string token)
        {
            var now = DateTime.UtcNow;
            var req1 = _context.EmailChangeRequests
                .OrderByDescending(x => x.RequestedOn)
                .Include(x => x.User);

            var req = req1
                .FirstOrDefault(x => x.VerificationToken == token && x.VerificationTokenExpiry >= now);
            if(req == null)
            {
                return false;
            }
            
            var user = req.User;
            _context.Users.Update(user);

            user.Email = req.Email;
            _context.Update(user);
            req.VerificationToken = null;
            req.VerificationTokenExpiry = null;
            _context.Update(req);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> forgotPasswordAsync(string email, string securityQuestion, string securityQuestionReply)
        {
            var myuser = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (myuser == null)
            {
                throw new KeyNotFoundException();
            } else
            {
                if (myuser.SecurityQuestion.Equals(securityQuestion) &&
                    myuser.SecurityQuestionAnswer.Equals(securityQuestionReply))
                {
                    if (myuser.IsEmailVerified ?? false)
                    {
                        var tempPassword = Authentication.generateTempPassord();
                        myuser.PasswordHash = Authentication.generateUserHash(tempPassword);
                        myuser.IsTemporaryPassword = true;
                        EmailOperations.sendPasswordChangeEmailAsync(tempPassword, myuser.Name, myuser.Email);
                        _context.Update(myuser);
                        await _context.SaveChangesAsync();
                        return true;
                    } else
                    {
                        var token = Authentication.generateEmailTokenHash();
                        myuser.VerificationToken = token;
                        myuser.VerificationTokenExpiry = DateTime.UtcNow.AddDays(1);
                        EmailOperations.sendVerificationEmailAsync(myuser.Name, myuser.Email, token);
                    }
                }
                return false;
            }
        }

        public List<UserModel> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public string GetSecurityQuestion(string email)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return null;
            }
            else
            {
                return user.SecurityQuestion;
            }
        }

        public UserModel GetUserById(int id)
        {
            var ret = _context.Users.FirstOrDefault(u => u.UserID == id);
            ret.LastUpdatedOn = DateTime.SpecifyKind(DateTime.Now,DateTimeKind.Unspecified);
            return ret;
        }

        public string Login(UserModel Userinfo)
        {
            var hash = Authentication.generateUserHash(Userinfo.PasswordHash);
            var User = _context.Users
                .Include(x => x.UserLocations)
                .ThenInclude(x => x.UserPermission)
                .FirstOrDefault(u => u.Email == Userinfo.Email && u.PasswordHash == hash);
            if (User == null)
            {
                return null;
            }

            if (!(User.IsEmailVerified ?? false))
            {
                string token = null;
                if(User.VerificationTokenExpiry < DateTime.UtcNow)
                {
                    while (token == null || _context.Users.Any(u => u.VerificationToken == token))
                    {
                        token = Authentication.generateEmailTokenHash();
                    }
                }
                else
                {
                    token = User.VerificationToken;
                }
                EmailOperations.sendVerificationEmailAsync(User.Name, User.Email, token);
                return null;
            }

            var ret = new Authentication(_context, _mapper).generateJwtToken(User);


            return ret;
        }

        public async void RegisterUser(UserModel User)
        {
            string token = null;
            while(token == null || _context.Users.Any(u=>u.VerificationToken == token))
            {
                token = Authentication.generateEmailTokenHash();
            }

            EmailOperations.sendVerificationEmailAsync(User.Name, User.Email, token);

            User.PasswordHash = Authentication.generateUserHash(User.PasswordHash);
            var now = DateTime.UtcNow;
            User.IsEmailVerified = false; 
            User.VerificationToken = token;
            User.VerificationTokenExpiry = now.AddHours(24);
            User.IsTemporaryPassword = false;
            _context.AddAsync(User);
            _context.SaveChanges();
        }

        public bool SaveChanges()
        {

            return _context.SaveChanges() >= 0;
            
        }

        public bool UpdateSecurityQuestion(string question, string answer)
        {
            return true;
        }

        public bool VerifyEmail(string token)
        {
            var user = _context.Users.SingleOrDefault(x => x.VerificationToken == token);
            if (user != null && user.VerificationTokenExpiry > DateTime.UtcNow)
            {
                user.IsEmailVerified = true;
                user.VerificationToken = null;
                user.VerificationTokenExpiry = null;
                _context.Update(user);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
