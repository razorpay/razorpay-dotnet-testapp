using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;

namespace RazorpaySampleApp.Controllers
{
    public class ChargeController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Verify(string razorpay_payment_id, string razorpay_order_id, string razorpay_signature)
        {
            Dictionary<string, string> attributes = new Dictionary<string, string>();
            attributes.Add("razorpay_payment_id", razorpay_payment_id);
            attributes.Add("razorpay_order_id", razorpay_order_id);
            attributes.Add("razorpay_signature", razorpay_signature);

            try
            {
                Utils.verifyPaymentSignature(attributes);

                // Please use below code to refund the payment
                // Refund refund = new Razorpay.Api.Payment(razorpay_payment_id).Refund();

                return View("Verify", razorpay_payment_id);
            }
            catch
            {
                return View("PaymentError");
            }
        }
    }
}