using System.ComponentModel.DataAnnotations;

namespace RazorpaySampleApp.Models
{
    public class PaymentRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public int Amount { get; set; } = 100;

        public string Name { get; set; } = "Daft Punk";

        [EmailAddress]
        public string Email { get; set; } = "customer@merchant.com";

        public string Contact { get; set; } = "+919999999999";

        public string Address { get; set; } = "Hello World";

        public string Description { get; set; } = "Tron Legacy";

        public string MerchantOrderId { get; set; } = "12312321";
    }
}