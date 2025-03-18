namespace CommunalServices.Models
{
    /// <summary>
    /// Имитация операций оплаты через банк.
    /// Реализует интерфейс <see cref="IBankPaymentOperation"/> для тестирования.
    /// </summary>
    public class MockBankOperation : IBankPaymentOperation
    {
        /// <summary>
        /// Имитация отправки информации о платеже в банк.
        /// </summary>
        /// <param name="payAccount">Объект, содержащий информацию о платеже.</param>
        public void SendPaymentAccount(PaymentAccount payAccount) 
        {
            // Здесь можно добавить логику для имитации отправки платежа
        }

        /// <summary>
        /// Имитация проверки успешности операции оплаты.
        /// </summary>
        /// <returns>Всегда возвращает <c>true</c>, имитируя успешную операцию.</returns>
        public bool IsSuccessPayOperation() 
        { 
            return true; 
        }
    }
}
