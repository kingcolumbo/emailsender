using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using SendGrid;
using SendGrid.Helpers.Mail;
using EmailSender.Models;

namespace EmailSender.Services
{
    public class EmailService
    {
        private EmailMessage EMessage { get; set; }

        public EmailService(EmailMessage e)
        {
            EMessage = e;
        }

        public string SendEmail()
        {
            var mailGunAttempt = SendToMailGun().StatusCode.ToString();

            if (mailGunAttempt != "OK")
            {
                return sendToSendGrid().Status.ToString();
            }            
            return mailGunAttempt;
        }

        private IRestResponse SendToMailGun()
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api",
                                            "key-eb955651862029a2068b2ff0c108a2f5");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandboxdf89bb0f96554d129c82b405bd74e91b.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Mailgun Sandbox <postmaster@sandboxdf89bb0f96554d129c82b405bd74e91b.mailgun.org>");
            request.AddParameter("to", EMessage.to);
            if (EMessage.cc != "")
            {
                request.AddParameter("cc", EMessage.cc);
            }
            if (EMessage.bcc != "")
            {
                request.AddParameter("bcc", EMessage.bcc);
            }
            request.AddParameter("subject", EMessage.subject);
            request.AddParameter("text", EMessage.message);
            request.Method = Method.POST;
            return client.Execute(request);
        }

        private async Task<Response> sendToSendGrid()
        {
            var client = new SendGridClient("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");
            var from = new EmailAddress("test@example.com", "Send Grid");
            var subject = EMessage.subject;
            var to = new EmailAddress(EMessage.to, EMessage.to);
            var htmlContent = EMessage.message;
            var plainTextContent = "<strong>" + EMessage.message + "<strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            if (EMessage.cc != "")
            {
                msg.AddCc(EMessage.cc);
            }
            if (EMessage.bcc != "")
            {
                msg.AddBcc(EMessage.bcc);
            }
            return await client.SendEmailAsync(msg);
        }
    }
}
