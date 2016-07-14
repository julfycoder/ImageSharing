using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace ImageSharing.Mail
{
    public class ImageSharingMailMessanger
    {
        public void Send(string smtpUserName, string smtpUserPassword, string toEmail, string subject, string body)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.Host = "smtp.mail.ru";
                    client.Port = 587;
                    client.UseDefaultCredentials = true;
                    client.Credentials = new NetworkCredential(smtpUserName, smtpUserPassword);

                    var msg = new MailMessage
                    {
                        IsBodyHtml = true,
                        BodyEncoding = Encoding.UTF8,
                        From = new MailAddress(smtpUserName),
                        Subject = subject,
                        Body = body,
                        Priority = MailPriority.Normal
                    };

                    msg.To.Add(toEmail);

                    client.Send(msg);

                }
            }
            catch
            {
            }
        }
    }
}