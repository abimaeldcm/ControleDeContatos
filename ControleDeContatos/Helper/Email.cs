using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace ControleDeContatos.Helper
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration; //Vai lá em appsetings e pega alguma informação que você quer.
                                                        //No caso aqui, nós queremos o SMTP
        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool Enviar(string email, string assunto, string mensagem)
        {
            try
            {
                string host = _configuration.GetValue<string>("SMTP:Host");
                string Nome = _configuration.GetValue<string>("SMTP:Nome");
                string username = _configuration.GetValue<string>("SMTP:UserName");
                string senha = _configuration.GetValue<string>("SMTP:Senha");
                int porta = _configuration.GetValue<int>("SMTP:Porta");
                
                MailMessage mail = new MailMessage()//Essa classe permite criar e configurar detalhes importantes da mensagem, como o remetente, destinatário(s), assunto, corpo da mensagem e anexos.
                {
                    From = new MailAddress(username, Nome)
                }; 
                mail.To.Add(email);
                mail.Subject = assunto;
                mail.Body = mensagem;
                mail.IsBodyHtml = true; //Posso colocar html no e-mail
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(host,porta))
                {
                    smtp.Credentials = new NetworkCredential(username,senha);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    return true;
                }
            }
            catch (System.Exception)
            {

                return false;
            }

            //Lembra de referenciar lá no sturtup.
        }
    }
}
