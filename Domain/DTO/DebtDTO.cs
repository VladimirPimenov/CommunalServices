using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.DTO
{
    /// <summary>
    /// DTO для передачи данных о задолженности.
    /// </summary>
    public class DebtDTO
    {
        public string PaymentNumber { get; set; }
        public string ResourceType { get; set; }
        public string ResourceProvider { get; set; }
        public DateTime AccrualDate { get; set; }
        public decimal Amount { get; set; }

        public Debt ConvertToDebt()
        {
            return new Debt
            {
                PaymentNumber = PaymentNumber,
                ResourceType = ResourceType,
                ResourceProvider = ResourceProvider,
                AccrualDate = AccrualDate,
                Amount = Amount
            };
        }

        public static DebtDTO FromDebt(Debt debt)
        {
            return new DebtDTO
            {
                PaymentNumber = debt.PaymentNumber,
                ResourceType = debt.ResourceType,
                ResourceProvider = debt.ResourceProvider,
                AccrualDate = debt.AccrualDate,
                Amount = debt.Amount
            };
        }
    }
}