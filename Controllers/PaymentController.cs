using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;
using RazorpaySampleApp.Models;
using RazorpaySampleApp.Services;

namespace RazorpaySampleApp.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IRazorpayClientFactory _clientFactory;

        public PaymentController(IConfiguration configuration, IRazorpayClientFactory clientFactory)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            return View(new PaymentRequest());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Start(PaymentRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", model.Amount); // this amount should be same as transaction amount
            input.Add("currency", "INR");
            input.Add("receipt", "12121");
            input.Add("payment_capture", 1);

            string key = _configuration["Razorpay:KeyId"];

            RazorpayClient client = _clientFactory.Create();

            Razorpay.Api.Order order = client.Order.Create(input);
            ViewBag.OrderId = order["id"].ToString();
            ViewBag.KeyId = key;

            return View("Pay", model);
        }
    }
}