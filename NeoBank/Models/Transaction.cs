namespace NeoBank.Models
{
    public class Transaction
    {
        public string SenderIBAN { get; set; }
        public string ReceiverIBAN { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
