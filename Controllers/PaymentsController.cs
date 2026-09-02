using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;
using RazorpaySampleApp.Models;
using RazorpaySampleApp.Services;

namespace RazorpaySampleApp.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IRazorpayClientFactory _clientFactory;

        public PaymentsController(IRazorpayClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            List<PaymentItem> payments = new List<PaymentItem>();

            try
            {
                RazorpayClient client = _clientFactory.Create();

                Dictionary<string, object> paymentRequest = new Dictionary<string, object>();
                paymentRequest.Add("count", 50);

                List<Payment> result = client.Payment.All(paymentRequest);
                foreach (Payment payment in result)
                {
                    payments.Add(new PaymentItem
                    {
                        Id = GetString(payment, "id"),
                        Amount = GetInt(payment, "amount"),
                        Currency = GetString(payment, "currency"),
                        Status = GetString(payment, "status"),
                        Method = GetString(payment, "method"),
                        Email = GetString(payment, "email"),
                        Contact = GetString(payment, "contact"),
                        AmountRefunded = GetInt(payment, "amount_refunded"),
                        CreatedAt = GetLong(payment, "created_at")
                    });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View(payments);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Refund(RefundRequest model)
        {
            if (!ModelState.IsValid)
            {
                TempData["RefundError"] = "Invalid refund request.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                RazorpayClient client = _clientFactory.Create();

                Dictionary<string, object> refundRequest = new Dictionary<string, object>();
                refundRequest.Add("amount", model.Amount);
                refundRequest.Add("speed", "normal");

                client.Payment.Fetch(model.PaymentId).Refund(refundRequest);

                TempData["RefundSuccess"] = $"Refund of ₹{model.Amount / 100m} issued for payment {model.PaymentId}. Refund takes a little time .. Do refresh after 30 seconds after initiating refund";
            }
            catch (Exception ex)
            {
                TempData["RefundError"] = $"Refund failed: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        private static string GetString(Payment payment, string key)
        {
            try { return payment[key]?.ToString(); }
            catch { return null; }
        }

        private static int GetInt(Payment payment, string key)
        {
            try { return System.Convert.ToInt32(payment[key]); }
            catch { return 0; }
        }

        private static long GetLong(Payment payment, string key)
        {
            try { return System.Convert.ToInt64(payment[key]); }
            catch { return 0; }
        }
    }
}