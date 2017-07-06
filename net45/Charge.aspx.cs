using Razorpay.Api;
using System;
using System.Collections.Generic;

namespace RazorpaySampleApp
{
    public partial class Charge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string paymentId = Request.Form["razorpay_payment_id"];

            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", 100); // this amount should be same as transaction amount

            string key = "<Enter your Api Key here>";
            string secret = "<Enter your Api Secret here>";

            RazorpayClient client = new RazorpayClient(key, secret);

            Dictionary<string, string> attributes = new Dictionary<string, string>();

            attributes.Add("razorpay_payment_id", paymentId);
            attributes.Add("razorpay_order_id", Request.Form["razorpay_order_id"]);
            attributes.Add("razorpay_signature", Request.Form["razorpay_signature"]);

            Utils.verifyPaymentSignature(attributes);

            Refund refund = new Razorpay.Api.Payment((string) paymentId).Refund();

            Console.WriteLine(refund["id"]);
        }
    }
}