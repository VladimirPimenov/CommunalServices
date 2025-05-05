using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.Entities;
using System.Text.Json;

namespace CommunalServices.Domain.UseCase
{
    public class AtolReceiptRegistrationService(IRepository _repository) : IReceiptRegistrationService
    {
        public async Task<bool> RegisterReceiptAsync(int abonentId, int paymentAccountId)
        {
            var abonent = await _repository.GetAbonentByIdAsync(abonentId);
            var paymentAccount = await _repository.GetPaymentAccountByIdAsync(paymentAccountId);

            if (abonent == null || paymentAccount == null)
                return false;

            var json = CreateJsonReceipt(abonent, paymentAccount);

            bool receiptResult = await SendJsonReceiptToAtol(json);
            return receiptResult;
        }

        private JsonContent CreateJsonReceipt(Abonent abonent, PaymentAccount paymentAccount)
        {
            var mockRequest = new { abonent, paymentAccount };

            var json = JsonContent.Create(mockRequest);

            return json;
        }

        private async Task<bool> SendJsonReceiptToAtol(JsonContent receipt)
        {
            HttpClient httpClient = new HttpClient();

            var httpResponce = await httpClient.PostAsync("https://online.atol.ru/possystem/v5/sell", receipt);

            return httpResponce.IsSuccessStatusCode; 
        }
    }
}
