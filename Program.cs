using System.Net.Mail;
using System.Net;

namespace SMTP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string host = "smtp.gmail.com";
            int port = 587;
            string email = "arsenobernihin@gmail.com" ;
            string password = "hmki dblc xdks fpck";

            SmtpClient smtpClient = new SmtpClient(host, port);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(email, password);
            //===============================
            
            Console.WriteLine("Введіть адресу:");
            string to = Console.ReadLine();
            Console.WriteLine("Введіть тему повідомлення:");
            string subject = Console.ReadLine();
            Console.WriteLine("enter path to bodyfile");
            string path = Console.ReadLine();
            //===============================
            
            string[] parts = path.Split('.');
            string type = parts[parts.Length - 1];
            string file = File.ReadAllText(path);

            MailMessage mailMessage = new MailMessage(email, to);
            mailMessage.Subject = subject;
            mailMessage.Body = file;
            
            if (type == "html")
            {
                mailMessage.IsBodyHtml = true;
            }

            //===============================
            Console.WriteLine("do you want to attach a file? (y/n)");
            string ans = Console.ReadLine();
            if (ans == "y")
            {
                Console.WriteLine("enter path to file");
                string path2 = Console.ReadLine();
                Attachment attachment = new Attachment(path2);
                mailMessage.Attachments.Add(attachment);
            }




            smtpClient.Send(mailMessage);
           
            
            
    




        }
    }
}
