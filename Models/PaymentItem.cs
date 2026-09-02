namespace RazorpaySampleApp.Models
{
    public class PaymentItem
    {
        public string Id { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public string Method { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public int AmountRefunded { get; set; }
        public long CreatedAt { get; set; }

        public decimal AmountInRupees => Amount / 100m;
        public decimal AmountRefundedInRupees => AmountRefunded / 100m;

        public bool CanRefund =>
            string.Equals(Status, "captured", System.StringComparison.OrdinalIgnoreCase)
            && AmountRefunded < Amount;
    }
}