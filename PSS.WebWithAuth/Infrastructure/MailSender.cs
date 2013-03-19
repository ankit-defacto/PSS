
namespace PSS.WebWithAuth.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Net.Mail;

    /// <summary>
    /// Send mail class
    /// </summary>
    public class MailSender
    {
        // list of destination mails
        public List<string> DestinationMails { get; private set; }

        // no default ctor
        private MailSender()
        {
        }

        // ctor with params
        public MailSender(params string[] destinationMails)
        {
            this.DestinationMails = new List<string>();
            for (int i = 0; i < destinationMails.Length; i++)
            {
                this.DestinationMails.Add(destinationMails[i]);
            }
        }

        // Send mail on checkin
        public void Send(string subject, string body)
        {
            this.Send(subject, body, string.Empty);
        }

        public void Send(string subject, string body, string attachment)
        {
            using (MailMessage message = new MailMessage())
            {
                message.Subject = subject;
                message.Body = body;
                if (IOUtils.FileExists(attachment))
                {
                    message.Attachments.Add(new Attachment(attachment));
                }

                foreach (var item in this.DestinationMails)
                {
                    message.To.Add(item);
                }

                using (SmtpClient mailClient = new SmtpClient())
                {
                    mailClient.Send(message);
                }
            }
        }
    }
}