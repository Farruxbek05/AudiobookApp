using System.Net;
using System.Net.Mail;

namespace Application.Service.Impl;

public class EmailService : IEmailService
{
    public async Task<bool> SendEmailAsync(string email, string otp)
    {
        try
        {
            var bussinessMail = "marufjonovfarruxbek846@gmail.com";
            var pass = "eevcmrxslkglipuq";
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(bussinessMail, pass)
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(bussinessMail),
                Subject = "Verification Code",
                Body = $"Dear {email}," +
                       "\nYou are using this email address to register on AudioBookApp." +
                       $"\n\nYour verification code is {otp}." +
                       "\nPlease use it to complete your registration before it expires." +
                       "\n\nIf you didn't request this, please ignore this email." +
                       "\n\nThank you!",
                IsBodyHtml = false
            };

            mailMessage.To.Add(email);

            await client.SendMailAsync(mailMessage);

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}

