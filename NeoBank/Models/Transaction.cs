namespace NeoBank.Models
{
    public class Transaction
    {
        public string SenderIban { get; set; }
        public string ReceiverIban { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
