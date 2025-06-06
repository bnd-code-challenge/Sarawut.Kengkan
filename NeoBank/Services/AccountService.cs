using NeoBank.Dtos;
using NeoBank.Repositories;

namespace NeoBank.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Task<string> CreateAccount(CreateAccountDto createAccountDto)
        {
            return _accountRepository.CreateAccount(createAccountDto);
        }

        public Task<AccountBalanceDto?> GetAccountBalance(string iBan)
        {
            return _accountRepository.GetAccountBalance(iBan);
        }

        public Task<List<AccountDto>> GetAllAccount()
        {
            return _accountRepository.GetAllAccount();
        }
    }
}
