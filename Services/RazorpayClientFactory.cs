using Razorpay.Api;

namespace RazorpaySampleApp.Services
{
    public interface IRazorpayClientFactory
    {
        RazorpayClient Create();
    }

    public class RazorpayClientFactory : IRazorpayClientFactory
    {
        private readonly IConfiguration _configuration;

        public RazorpayClientFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public RazorpayClient Create()
        {
            string key = _configuration["Razorpay:KeyId"];
            string secret = _configuration["Razorpay:KeySecret"];
            return new RazorpayClient(key, secret);
        }
    }
}