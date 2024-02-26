using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using pLocals.Data;
using pLocals.Models;

namespace pLocals.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;
        private readonly AppDbContext _context;

        public AccountController(ILogger<AccountController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _context = appDbContext;
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
            
            _context.Accounts.Add(a);
            
            await _context.SaveChangesAsync();
            
            return Content(new Account());
        }
    }
}
