using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailSender
{
    private static readonly string _fromEmail = "apexbank98@gmail.com";
    private static readonly string _password = "rqes hkmf ezgv fbdo";
    private static readonly string _smtpServer = "smtp.gmail.com";
    private static readonly int _smtpPort = 587;
    private static readonly bool _enableSsl = true;

    public static async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
    {
        try
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(_fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient(_smtpServer, _smtpPort))
                {
                    smtp.Credentials = new NetworkCredential(_fromEmail, _password);
                    smtp.EnableSsl = _enableSsl;
                    await smtp.SendMailAsync(mail);
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending email to {toEmail}: {ex.Message}");
            return false;
        }
    }
}