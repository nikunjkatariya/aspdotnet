using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using PaymentReceiver.Models;
using System.Text;

namespace PaymentReceiver.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;
        private static QueueClient queueClient;
        static List<Payment> payments= new List<Payment>();
        private dynamic client;
        private ServiceBusReceiver receiver;
        private static ServiceBusReceivedMessage receivedMessage;
        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
            client = new ServiceBusClient(_configuration["QueueConnectionString"]);
            receiver = client.CreateReceiver(_configuration["QueueName"]);
        }
        // GET: PaymentController/Create
        public async Task<ActionResult> Create()
        {
            receivedMessage = await receiver.ReceiveMessageAsync();
            string body = receivedMessage.Body.ToString();
            var payment = JsonConvert.DeserializeObject<Payment>(body);
            /*Payment pd = new Payment();*/
            return View(payment);
        }

        // POST: PaymentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,ProductQuantity,Amount,Sum")] Payment payment)
        {
/*            try
            {*/
                Console.WriteLine(payment.Id + "||||" + payment.ProductQuantity + "||||" + payment.Amount);
            await receiver.CompleteMessageAsync(receivedMessage);
            payments.Add(new Payment {Id=payment.Id,ProductQuantity=payment.ProductQuantity,Amount=payment.Amount});
                return RedirectToAction(nameof(Index));
            /*}
            catch
            {
                return View(payment);
            }*/
        }
        // GET: PaymentController
        public ActionResult Index()
        {
            return View(payments);
        }

        // GET: PaymentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PaymentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaymentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaymentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaymentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
