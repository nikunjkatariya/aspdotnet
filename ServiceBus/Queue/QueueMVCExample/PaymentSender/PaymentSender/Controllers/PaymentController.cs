using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using PaymentSender.Models;
using System.Text;

namespace PaymentSender.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;
        private QueueClient queueClient;
        static List<Payment> payments = new List<Payment>();
        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
            queueClient = new QueueClient(_configuration["QueueConnectionString"], _configuration["QueueName"]);
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

        // GET: PaymentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,ProductQuantity,Amount")] Payment payment)
        {
            try
            {
                payments.Add(new Payment { Id = payment.Id, ProductQuantity = payment.ProductQuantity, Amount = payment.Amount });
                await using var client = new ServiceBusClient(_configuration["QueueConnectionString"]);
                ServiceBusSender sender = client.CreateSender(_configuration["QueueName"]);
                var paymentJson = JsonConvert.SerializeObject(payment);
                /*var paymentMessage = new Message(Encoding.UTF8.GetBytes(paymentJson))
                {
                    MessageId = Guid.NewGuid().ToString(),
                    ContentType = "application/json"
                };*/
                ServiceBusMessage message = new ServiceBusMessage(paymentJson);
                await sender.SendMessageAsync(message);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
