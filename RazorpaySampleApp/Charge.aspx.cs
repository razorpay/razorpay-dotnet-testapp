using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorpaySampleApp
{
    public partial class Charge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string paymentId = Request.Form["razorpay_payment_id"];

            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", 100); // this amount should be same as transaction amount

            string key = "Your Key";
            string secret = "Your Secret";

            RazorpayClient client = new RazorpayClient(key, secret);

            Razorpay.Api.Payment payment = client.Payment.Fetch(paymentId);
            Razorpay.Api.Payment capturedPayment = payment.Capture(input);
        }
    }
}