namespace NeoBank.Repositories
{
    public interface IGetIBanRepository
    {
        public Task<string> GetIBAN(string country);
    }
}
