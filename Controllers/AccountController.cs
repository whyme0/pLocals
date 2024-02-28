using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using pLocals.Data;
using pLocals.Models;
using pLocals.Repository;

namespace pLocals.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;
        private readonly AppDbContext _context;
        private readonly AccountRepository _accRepository;

        public AccountController(ILogger<AccountController> logger, AccountRepository accountRepository, AppDbContext context)
        {
            _logger = logger;
            _accRepository = accountRepository;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(AccountDTO account)
        {
            Account a = new Account() { 
                Title = account.Title,
                Login = account.Login,
                Password = account.Password,
                Notes = account.Notes
            };

            _accRepository.Create(a);
            
            await _context.SaveChangesAsync();
            
            return Content();
        }
    }
}
