using ReminderMe.DomainCore.DBModel.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ReminderMe.API.Helper
{
    public static class MailHelper
    {
        public static void SendMail(IReadOnlyList<PrivateDay> privateDaysList)
        {
            SmtpClient client = new SmtpClient();
            // Specify the email sender.
            // Create a mailing address that includes a UTF8 character
            // in the display name.
            MailAddress from = new MailAddress("bilgi@ozelgunhatirlat.com");
            // Set destinations for the email message.
            MailAddress to = new MailAddress("mnk0606@hotmail.com");
            StringBuilder sb = new StringBuilder(); 
            // Specify the message content.
            MailMessage message = new MailMessage(from, to);
            try
            {
                foreach (var day in privateDaysList)
                {
                    sb.Append(day.PrivateDayName + "-Tarihi:" + day.PrivateDayDate.ToString("dd.MM.yyyy") + Environment.NewLine);
                }

                message.Body = sb.ToString();
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Subject = "Özel Gün Hatırlatma Mesajı";
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                message.IsBodyHtml = true;
                client.EnableSsl = false;
                client.Host = "mail.ozelgunhatirlat.com";
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.Timeout = 10000;
                client.Credentials = new NetworkCredential("bilgi@ozelgunhatirlat.com", "5:.U9kdo:S.GsD08");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(message);
                message.Dispose();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
