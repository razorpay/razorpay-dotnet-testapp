using System.ComponentModel.DataAnnotations;

namespace RazorpaySampleApp.Models
{
    public class RefundRequest
    {
        [Required(ErrorMessage = "Payment id is required.")]
        public string PaymentId { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public int Amount { get; set; }
    }
}