using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace crearics
{
    class email
    {
        public email(String emailInvitar, String nombre, String emailOrganizador, String archivo,String nombreOrganizador)
        {
            SmtpClient client = new SmtpClient("mx1.hostinger.mx", 587);
            client.EnableSsl = true;
            MailAddress from = new MailAddress("pruebas@unprogramador.com", "Pruebas un programador");
            MailAddress to = new MailAddress(emailInvitar, nombre);
            MailMessage msn = new MailMessage(from, to);
            msn.Body = "Hola "+nombre+" Se te hace una invitacion para un evento departe de " + nombreOrganizador + " <" + emailOrganizador + ">" + " solo da click en el archivo con extension ics para agregarlo a tu calendario .\n gracias!";
            msn.Attachments.Add(new Attachment("./evento/"+archivo));
            msn.Subject = "Invitacion de "+nombreOrganizador+"<"+ emailOrganizador+">";
            msn.CC.Add(new MailAddress("cesarflores2205@gmail.com"));
            NetworkCredential myCreds = new NetworkCredential("pruebas@unprogramador.com", "hola.mundo", "");
            client.Credentials = myCreds;
            try
            {

                client.Send(msn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is:" + ex.ToString());
            }
        }
        /*public Boolean sendEmail()
        {
            MailAddress from = new MailAddress("ben@contoso.com", "Ben Miller");
            MailAddress to = new MailAddress("jane@contoso.com", "Jane Clayton");
            MailMessage message = new MailMessage(from, to);
            // message.Subject = "Using the SmtpClient class.";
            message.Subject = "Using the SmtpClient class.";
            message.Body = @"Using this feature, you can send an email message from an application very easily.";
            // Add a carbon copy recipient.
            MailAddress copy = new MailAddress("Notification_List@contoso.com");
            message.CC.Add(copy);
            SmtpClient client = new SmtpClient(server);
            // Include credentials if the server requires them.
            client.Credentials = CredentialCache.DefaultNetworkCredentials;
            Console.WriteLine("Sending an email message to {0} by using the SMTP host {1}.",
                 to.Address, client.Host);

            try
            {
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateCopyMessage(): {0}",
                            ex.ToString());
                return false;
            }
            
        }*/
    }
}
