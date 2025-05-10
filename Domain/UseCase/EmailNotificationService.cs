using System.Net;
using System.Net.Mail;

using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.UseCase
{
    public class EmailNotificationService(IConfiguration config): INotificationService
    {
        private readonly string companyEmail = config.GetValue<string>("CompanyEmail");

        public void SendNewAbonentPasswordToEmail(Abonent abonent)
        {
            var passwordMessage = CreatePasswordNoticeMessage(abonent);

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Credentials = new NetworkCredential(companyEmail, "password"),
                EnableSsl = true
            };

            smtpClient.Send(passwordMessage);
        }

        public void SendPaymentReceipt(Abonent abonent, PaymentAccount paymentAccount)
        {
            throw new NotImplementedException();
        }

        private MailMessage CreatePasswordNoticeMessage(Abonent abonent)
        {
            var senderEmail = new MailAddress(companyEmail);
            var recepientEmail = new MailAddress(abonent.Email);

            return new MailMessage(senderEmail, recepientEmail)
            {
                Subject = "Новый пароль CommunalServices",
                Body = $"{abonent.FirstName}, ваш новый пароль от учётной записи: {abonent.Password}."
            };
        }
    }
}
