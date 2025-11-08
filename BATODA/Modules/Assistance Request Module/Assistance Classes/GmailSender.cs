using System.Net;
using System.Net.Mail;
using System.IO;

namespace BATODA.Modules.Assistance_Request_Module.Assistance_Classes
{
    internal class GmailSender
    {
        public void SendAssistanceEmail(
            string recipientEmail,
            string fullName,
            string bodyNumber,
            string typeOfAid,
            string requestedBy,
            string amount,
            string assistanceThru,
            string gcashNumber,
            string dateRequested,
            string targetDate,
            string status,
            string proofFilePath)
        {
            string body = $@"
            <html>
            <body>
                <h2>Assistance Request Details</h2>
                <p><b>Full Name:</b> {fullName}</p>
                <p><b>Body Number:</b> {bodyNumber}</p>
                <p><b>Type of Aid:</b> {typeOfAid}</p>
                <p><b>Requested By:</b> {requestedBy}</p>
                <p><b>Amount:</b> {amount}</p>
                <p><b>Assistance Thru:</b> {assistanceThru}</p>
                <p><b>Gcash Number:</b> {gcashNumber}</p>
                <p><b>Date Requested:</b> {dateRequested}</p>
                <p><b>Target Date:</b> {targetDate}</p>
                <p><b>Status:</b> {status}</p>
                <p>Attached is the proof of request.</p>
            </body>
            </html>";

            MailMessage mail = new MailMessage();
            mail.To.Add(recipientEmail);
            mail.Subject = "Assistance Request Submission";
            mail.Body = body;
            mail.IsBodyHtml = true;

            if (File.Exists(proofFilePath))
            {
                Attachment attachment = new Attachment(proofFilePath);
                mail.Attachments.Add(attachment);
            }

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("your_email@gmail.com", "your_password");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}
