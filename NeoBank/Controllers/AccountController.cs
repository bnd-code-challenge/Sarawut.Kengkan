using Microsoft.AspNetCore.Mvc;
using NeoBank.Dtos;
using NeoBank.Models;
using NeoBank.Services;
using System.Security.Principal;

namespace NeoBank.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountDto account)
        {
            try
            {
                var result = await _accountService.CreateAccount(account);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{IBAN}")] 
        public async Task<IActionResult> GetBalance(string IBAN)
        {
            try
            {
                var result = await _accountService.GetAccountBalance(IBAN);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccount()
        {
            try
            {
                var result = await _accountService.GetAllAccount();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
