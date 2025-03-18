using System.ComponentModel.DataAnnotations;

namespace CommunalServices.Models
{
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
                PaymentNumber = this.PaymentNumber,
                ResourceType = this.ResourceType,
                ResourceProvider = this.ResourceProvider,
                AccrualDate = this.AccrualDate,
                Amount = this.Amount
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