﻿using NeoBank.Dtos;

namespace NeoBank.Repositories
{
    public interface IAccountRepository
    {
        public Task<string> CreateAccount(CreateAccountDto createAccountDto);

        public Task<List<AccountDto>> GetAllAccount();

        public Task<AccountBalanceDto?> GetAccountBalance(string iBan);
    }
}
