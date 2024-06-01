using System.Net.Mail;
using Application.ExternalAPI;
using Application.Settings;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ExternalAPI.Email
{
    public class SendGridEmail : ISendGridEmail
    {
        private readonly Mailsetting _mailSetting;

        #region Ctor
        public SendGridEmail(IOptions<Mailsetting> mailSetting)
        {
            _mailSetting = mailSetting.Value;
        }

        #endregion
        #region Send Grid

        public async Task<bool> SendMail(string to, string subject, string body, string fromName = "", string replyToEmail = "")
        {
            bool status = false;
            if (_mailSetting.IsUsingSendGridKey == true)
            {
                try
                {
                    var client = new SendGridClient(_mailSetting.SendGridKey);

                    var msg = MailHelper.CreateSingleEmail(new EmailAddress(_mailSetting.FromEmail), new EmailAddress(to), subject, "", body);
                    if (!string.IsNullOrEmpty(fromName))
                    {
                        msg.SetFrom(_mailSetting.FromEmail, fromName);
                    }
                    if (!string.IsNullOrEmpty(replyToEmail))
                    {
                        msg.ReplyTo = new EmailAddress()
                        {
                            Email = replyToEmail,
                            Name = ""
                        };
                    }
                    var response = await client.SendEmailAsync(msg);
                    if (response.IsSuccessStatusCode)
                    {
                        status = true;
                    }
                }
                catch
                {
                    status = false;
                }
                return status;
            }
            else
            {
                try
                {
                    using (MailMessage mailMessage = new())
                    {
                        mailMessage.From = new MailAddress(_mailSetting.FromEmail);
                        mailMessage.Subject = subject;
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true;
                        mailMessage.To.Add(new MailAddress(to));
                        SmtpClient smtp = new()
                        {
                            Host = _mailSetting.SmtpHost,
                            EnableSsl = Convert.ToBoolean(_mailSetting.EnableSsl)
                        };
                        System.Net.NetworkCredential NetworkCred = new()
                        {
                            UserName = _mailSetting.UserName,
                            Password = _mailSetting.Password
                        };
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = _mailSetting.SmtpPort;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Timeout = 60000;
                        smtp.Send(mailMessage);
                        mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                        status = true;
                    }
                }
                catch
                {
                    status = false;
                }

            }
            return status;

        }
        #endregion
    }
}
