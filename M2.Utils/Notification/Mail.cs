using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace M2.Utils.Notification
{

    public  abstract class Mail : IDisposable
    {
        protected string MailOrigin {get; set; }
        protected string Password {get;set; }
        public string Title {get;set; }
        public StringBuilder Body { get; set; } = new StringBuilder();    
        public List<string> Destinations {get;set; }     
        public MailPriority MailPriority {get;set;} = MailPriority.Normal;
        
        private MailMessage _mail = new MailMessage();
        protected SmtpClient client = new SmtpClient();

        protected abstract void ConfigureMailCredetials();
        protected abstract void ConfigurePort();
        protected abstract void ConfigureHost();
        protected abstract void ConfigureSSL();

        

        public Mail()
        {
            this.Destinations = new List<string>();
        }

        private void SetMailDestinations()
        {
            foreach(var prop in Destinations)
                _mail.To.Add(prop.ToString());
        }

        private void AddMailOrigin()
        {
            _mail.From = new MailAddress(MailOrigin, "", System.Text.Encoding.UTF8);
        }

        private void AddMailTitle()
        {
            _mail.Subject = Title;
            _mail.SubjectEncoding = System.Text.Encoding.UTF8;
        }
        
        private void AddMailBody()
        {
            _mail.Body = Body.ToString();
            _mail.BodyEncoding = System.Text.Encoding.UTF8;
        }

        private void BodyHtml()
        {
            _mail.IsBodyHtml = true;
        }

        protected virtual void Priority()
        {
            _mail.Priority = MailPriority.Normal;
        }


        private void ConstructorMail()
        {
            AddMailOrigin();  
            SetMailDestinations();   
            AddMailTitle();
            AddMailBody();
            BodyHtml();
            Priority();
        }

        private void ConfigureServer()
        {
            this.ConfigureMailCredetials();
            this.ConfigurePort();
            this.ConfigureHost();
            this.ConfigureSSL();
            this.ConfigureCredentials();           
        }

     
        public void Send()
        { 
            ConstructorMail();
            ConfigureServer();
            client.Send(_mail);
        }

        public Task SendAsync()
        {
            return Task.Run(() => {

                ConstructorMail();
                ConfigureServer();
                client.Send(_mail);
            });
           
        }
        
        protected void ConfigureCredentials()
        {
            client.Credentials = new NetworkCredential(MailOrigin ,Password);
        }


        public void Limpar()
        {
            Title = string.Empty;
            Destinations.Clear();
            Body.Clear();
            _mail.To.Clear();
        }

        public void Dispose()
        {
            _mail.To.Clear();
            _mail.Dispose();
            client.Dispose();
            Body = null;
            Destinations = null;
            GC.SuppressFinalize(this);
        }

        public void AddAnexo(string fileName)
        {
            var anexo = new Attachment(fileName);
            _mail.Attachments.Add(anexo);
        }
    }

   

   


    
}