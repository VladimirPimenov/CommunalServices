using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.Entities;
using System.Net;
using System.Net.Mail;

namespace CommunalServices.Domain.ContractsRealization
{
    public class EmailNoticeService: IEmailNoticeService
    {
        public void SendNewAbonentPassword(Abonent abonent)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

            smtp.Credentials = new NetworkCredential("company@email.com", "password");
            smtp.EnableSsl = true;

            MailMessage passwordMessage = CreatePasswordNoticeMessage(abonent);

            smtp.Send(passwordMessage);
        }
        private MailMessage CreatePasswordNoticeMessage(Abonent abonent)
        {
            MailAddress senderEmail = new MailAddress("company@email.com");
            MailAddress recepientEmail = new MailAddress(abonent.Email);

            MailMessage passwordNotice = new MailMessage(senderEmail, recepientEmail);
            passwordNotice.Subject = "Новый пароль CommunalServices";
            passwordNotice.Body = $"{abonent.FirstName}, ваш новый пароль от учётной записи: {abonent.Password}.";

            return passwordNotice;
        }

        public void SendPaymentReceipt(Abonent abonent, PaymentAccount paymentAccount)
        {
            throw new NotImplementedException();
        }
    }
}
