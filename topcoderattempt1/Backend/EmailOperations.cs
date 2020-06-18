using MimeKit.Text;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace topcoderattempt1.Backend
{
    public class EmailOperations
    {
        private async static Task sendMessage(string name, string subject, string address, string body)
        {
            var messageToSend = new MimeMessage
            {
                Sender = new MailboxAddress("C", "ccxbox2000@gmail.com"),
                Subject = subject,
            };

            messageToSend.Body = new TextPart(TextFormat.Html)
            {
                Text = body
            };
            messageToSend.To.Add(new MailboxAddress(name, address));

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.MessageSent += (sender, args) => {

                };

                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
                smtp.Connect("smtp.gmail.com", 465, true);
                smtp.Authenticate("ccxbox2000@gmail.com", "xbox1234");
                await smtp.SendAsync(messageToSend);
                smtp.Disconnect(true);
            }
        }
        public static async Task sendVerificationEmailAsync(string name, string address, string token)
        {
            var body = Constants.baseUrl + "auth/verifyEmail?token=" + token;
            await sendMessage(name, "Email Verification Link", address, body);
        }
        public async static Task sendVerificationEmail(string name, string address, string token, bool update)
        {
            var body = Constants.baseUrl + "auth/verifyEmail?token=" + token + "&update="+ update.ToString();
            await sendMessage(name, "Email Verification Link", address, body);
        }
        public static async Task sendPasswordChangeEmailAsync(string password, string name, string address)
        {
            var bodyText = "Hello There! To regain access to your account, use this temporary password";
            await sendMessage(name, "Password Reset", address, bodyText);
        }
    }
}
