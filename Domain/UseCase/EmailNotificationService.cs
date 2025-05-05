using System.Net;
using System.Net.Mail;

using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.UseCase
{
    public class EmailNotificationService: INotificationService
    {
        public void SendNewAbonentPasswordToEmail(Abonent abonent)
        {
            var passwordMessage = CreatePasswordNoticeMessage(abonent);

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Credentials = new NetworkCredential("company@email.com", "password"),
                EnableSsl = true
            };

            smtpClient.Send(passwordMessage);
        }

        public void SendPaymentReceipt(Abonent abonent, PaymentAccount paymentAccount)
        {
            throw new NotImplementedException();
        }

        private static MailMessage CreatePasswordNoticeMessage(Abonent abonent)
        {
            var senderEmail = new MailAddress("company@email.com");
            var recepientEmail = new MailAddress(abonent.Email);

            return new MailMessage(senderEmail, recepientEmail)
            {
                Subject = "Новый пароль CommunalServices",
                Body = $"{abonent.FirstName}, ваш новый пароль от учётной записи: {abonent.Password}."
            };
        }
    }
}
