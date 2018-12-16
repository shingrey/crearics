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
            //puerto para enviar correo
            SmtpClient client = new SmtpClient("mx1.hostinger.mx", 587);
            client.EnableSsl = true;
            //email que envia
            MailAddress from = new MailAddress("pruebas@unprogramador.com", "Pruebas un programador");
            MailAddress to = new MailAddress(emailInvitar, nombre);
            MailMessage msn = new MailMessage(from, to);
            msn.Body = "Hola "+nombre+" Se te hace una invitacion para un evento departe de " + nombreOrganizador + " <" + emailOrganizador + ">" + " solo da click en el archivo con extension ics para agregarlo a tu calendario .\n gracias!";
            msn.Attachments.Add(new Attachment("./evento/"+archivo));
            msn.Subject = "Invitacion de "+nombreOrganizador+"<"+ emailOrganizador+">";
            //hago una copia
            msn.CC.Add(new MailAddress("shingrey@unprogramador.com"));
            //credenciales
            NetworkCredential myCreds = new NetworkCredential("pruebas@unprogramador.com", "contraseña", "");
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

    }
}
