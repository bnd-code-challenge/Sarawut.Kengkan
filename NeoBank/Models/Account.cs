namespace NeoBank.Models
{
    public class Account
    {
        public string IBAN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
