
using PaymentGatewatConfirmationWebAPI.Models;

namespace PaymentGatewatConfirmationWebAPI.Services
{
    public interface ICosmosDbService
    {
        Task AddPayment(Payment payment);
    }
}
