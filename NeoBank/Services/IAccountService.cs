using NeoBank.Dtos;

namespace NeoBank.Services
{
    public interface IAccountService
    {
        public Task<string> CreateAccount(CreateAccountDto createAccountDto);

        public Task<List<AccountDto>> GetAllAccount();

        public Task<AccountBalanceDto?> GetAccountBalance(string iBan);
    }
}
