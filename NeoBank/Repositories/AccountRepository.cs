using NeoBank.Data;
using NeoBank.Dtos;

namespace NeoBank.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<string> CreateAccount(CreateAccountDto createAccountDto)
        {
            throw new NotImplementedException();
        }

        public Task<AccountBalanceDto> GetAccountBalance(string iBan)
        {
            throw new NotImplementedException();
        }

        public Task<AccountDto[]> GetAllAccount()
        {
            throw new NotImplementedException();
        }
    }
}
