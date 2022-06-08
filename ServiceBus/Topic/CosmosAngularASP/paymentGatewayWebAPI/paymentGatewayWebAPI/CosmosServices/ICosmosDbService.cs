using paymentGatewayWebAPI.Models;

namespace paymentGatewayWebAPI.CosmosServices
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Payment>> GetPayments(string queryString);

        Task AddPayment(Payment payment);
    }
}
