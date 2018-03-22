using System;
using System.Net.Mail;

namespace ASANM.Site.Contato
{
    public partial class Contato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Enviar(object sender, EventArgs e)
        {
            //Define os dados do e-mail
            string nomeRemetente = txtNome.Text;
            string emailRemetente = txtEmail.Text;

            string emailDestinatario = "secretaria@ansdnpm.org.br";
            //string emailComCopia = "email@comcopia.com.br";
            //string emailComCopiaOculta = "email@comcopiaoculta.com.br";

            string assuntoMensagem = "[Contato] - Novo e-mail enviado através do site da ANSDNPM";

            string conteudoMensagem = "";

            conteudoMensagem += "<b>Nome:</b> " + txtNome.Text + "<br />";
            conteudoMensagem += "<b>Telefone:</b> " + txtTelefone.Text + "<br />";
            conteudoMensagem += "<b>E-mail:</b> " + txtEmail.Text + "<br />";
            conteudoMensagem += "<b>Mensagem:</b><br />" + txtMensagem.Text;

            //Cria objeto com dados do e-mail.
            MailMessage objEmail = new MailMessage();

            //Define o Campo From e ReplyTo do e-mail.
            objEmail.From = new MailAddress(nomeRemetente + "<" + emailRemetente + ">");

            //Define os destinatários do e-mail.
            objEmail.To.Add(emailDestinatario);

            //Enviar cópia para.
            //objEmail.CC.Add(emailComCopia);

            //Enviar cópia oculta para.
            //objEmail.Bcc.Add(emailComCopiaOculta);

            //Define a prioridade do e-mail.
            objEmail.Priority = MailPriority.Normal;

            //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
            objEmail.IsBodyHtml = true;

            //Define título do e-mail.
            objEmail.Subject = assuntoMensagem;

            //Define o corpo do e-mail.
            objEmail.Body = conteudoMensagem;

            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");


            // Caso queira enviar um arquivo anexo
            //Caminho do arquivo a ser enviado como anexo
            //string arquivo = Server.MapPath("arquivo.jpg");

            // Ou especifique o caminho manualmente
            //string arquivo = @"e:\home\LoginFTP\Web\arquivo.jpg";

            // Cria o anexo para o e-mail
            //Attachment anexo = new Attachment(arquivo, System.Net.Mime.MediaTypeNames.Application.Octet);

            // Anexa o arquivo a mensagemn
            //objEmail.Attachments.Add(anexo);

            //Cria objeto com os dados do SMTP
            SmtpClient objSmtp = new SmtpClient();

            //Alocamos o endereço do host para enviar os e-mails, localhost(recomendado) 
            objSmtp.Host = "localhost";
            objSmtp.Port = 25;

            //Enviamos o e-mail através do método .send()
            try
            {
                objSmtp.Send(objEmail);
                Response.Write("<script language='JavaScript'>alert('Sua mensagem foi enviada com sucesso');window.location='Contato.aspx';</script>");
            }
            catch (Exception ex)
            {
                Response.Write("Ocorreram problemas no envio do e-mail. Erro = " + ex.Message);
            }
            finally
            {
                //excluímos o objeto de e-mail da memória
                objEmail.Dispose();
                //anexo.Dispose();
            }
        }
    }
}