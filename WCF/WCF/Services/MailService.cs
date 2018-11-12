using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WCF.Classes;
using WCF.Interfaces;
namespace WCF
{
    public class MailService : IMail
    {
        public void SendCode(UserDTO user, int code)
        {
            #region

            string mail = @"support@lmpk.s-host.net";
            string pass = "27082002AaV";

            #endregion

            SmtpClient smtpClient;
            MailMessage messege;
            smtpClient = new SmtpClient("mail.lmpk.s-host.net", 587);
            smtpClient.Credentials = new NetworkCredential(mail, pass);

            MailAddress mailAddress = new MailAddress(mail);
            messege = new MailMessage();
            messege.From = mailAddress;
            messege.To.Add(user.Email);
            messege.Subject = "Hello "+user.Login;
            messege.Body = "<body style='background: #666666; font-weight:bold; color:white;'><center><h1><br><br>Your code: " + code + "</h3>\n<h3><br>Date: " + DateTime.Now + "<h3><br></center></body>";
            messege.IsBodyHtml = true;
            //smtpClient.EnableSsl = true;
            smtpClient.Send(messege);
        }

    
    }
}
