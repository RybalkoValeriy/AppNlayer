using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Net.Mail;

namespace App.BLL.Services
{
    public class EmailServiceIdentity : IIdentityMessageService
    {
        // отправка имеил
        public async Task SendAsync(IdentityMessage message)
        {
            var from = "burger.request.@gmail.com";
            var pass = "JKfd72k32bnxfx?";
            //todo:password mail hidden
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(from, pass),
                EnableSsl = true
            };

            var mail = new MailMessage(from, message.Destination)
            {
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = true
            };
            await client.SendMailAsync(mail);
        }
    }
}
