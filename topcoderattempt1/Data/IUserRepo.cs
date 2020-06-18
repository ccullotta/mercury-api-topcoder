using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using topcoderattempt1.Models;

namespace topcoderattempt1.Data
{
    public interface IUserRepo
    {

        string Login(UserModel User);
        void RegisterUser(UserModel User);

        bool VerifyEmail(string token);
        List<UserModel> GetAllUsers();
        bool SaveChanges();
        UserModel GetUserById(int id);

        bool ChangeEmailRequest(string token);

        bool UpdateSecurityQuestion(string question, string answer);
        string GetSecurityQuestion(string email);
        Task<bool> forgotPasswordAsync(string email, string securityQuestion, string securityQuestionReply);
    }
}
