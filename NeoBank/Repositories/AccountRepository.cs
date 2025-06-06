using Microsoft.EntityFrameworkCore;
using NeoBank.Data;
using NeoBank.Dtos;
using NeoBank.Models;

namespace NeoBank.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;
        private readonly IGetIBanRepository _banRepository;

        public AccountRepository(AppDbContext context, IGetIBanRepository getIBanRepository)
        {
            _context = context;
            _banRepository = getIBanRepository;
        }

        public async Task<string> CreateAccount(CreateAccountDto createAccountDto)
        {
            var IBAN = await _banRepository.GetIBAN("NL");
            var account = new Account
            {
                IBAN = IBAN,
                FirstName = createAccountDto.FirstName,
                LastName = createAccountDto.LastName,
                Email = createAccountDto.Email ?? "",
                CreateDate = DateTime.Now,
            };
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return await Task.FromResult(IBAN);
        }

        public async Task<AccountBalanceDto?> GetAccountBalance(string IBan)
        {
            var result = await _context.Accounts.FirstOrDefaultAsync(a => a.IBAN == IBan);
            if (result == null) return null;
            var accBalance = new AccountBalanceDto
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                Balance = result.Balance,
            };
            return await Task.FromResult(accBalance);
        }

        public async Task<List<AccountDto>> GetAllAccount()
        {
            var result = await _context.Accounts
                .Select(x => new AccountDto
                {
                    IBAN = x.IBAN,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email
                }).ToListAsync();
            return await Task.FromResult(result);
        }
    }
}
