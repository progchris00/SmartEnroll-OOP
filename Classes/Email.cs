using System.Net;
using System.Net.Mail;

namespace Itec102.StudentManagementSystem
{
    public class Email
    {
        public static void Send(string email, string lastname)
        {
            string fromMail = "smartenrollmessage@gmail.com";
            string fromPassword = "atfg ibcs kjfl phrm";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = $"Congratulations, Mr. {lastname}!";
            message.To.Add(new MailAddress(email));
            message.Body = $"<html><body>Dear {lastname},<br><br> Good day! We are delighted to inform you that your application has been successfully reviewed, and we are thrilled to officially welcome you to LSPU - LB! <br><br> Your dedication to education and commitment to excellence have truly impressed our admissions team. We believe that your presence will enrich our academic community, and we look forward to supporting you on your educational journey.<br><br> Please standby for further instructions.<br><br> Best regards,<br><br> SmartEnroll<br> LSPU-LB Admissions Office</body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);
        }
    }
}