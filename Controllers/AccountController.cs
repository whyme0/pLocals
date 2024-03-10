using Microsoft.AspNetCore.Mvc;
using pLocals.Data;
using pLocals.Models;
using pLocals.Models.DTOs;
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

        [HttpGet]
        public ICollection<Account> Get()
        {
            return _accRepository.FindAll().ToList();
        }

        [HttpGet]
        public Account? Get(int id)
        {
            return _accRepository.Find(a => a.AccountId == id).FirstOrDefault();
        }

        [HttpGet]
        public Account? Get(string title)
        {
            return _accRepository.Find(a => a.Title == title).FirstOrDefault();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AccountDTO account)
        {
            Account a = new Account() { 
                Title = account.Title,
                Login = account.Login,
                Password = account.Password,
                Note = account.Note
            };

            _accRepository.Create(a);
            
            await _context.SaveChangesAsync();
            
            return Created();
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            Account? a = _accRepository.Find(a => a.AccountId == id).FirstOrDefault();

            if (a == null)
                return NotFound();
           
            _accRepository.Delete(a);
            
            await _context.SaveChangesAsync();
            
            return Content("Account successfully deleted");
        }

        [HttpPost]
        public async Task<ActionResult> Update(int id, AccountDTO accountDTO)
        {
            Account? a = _accRepository.Find(a => a.AccountId == id).FirstOrDefault();
            if (a == null)
                return NotFound();
            
            _accRepository.Update(a);
            return Ok("Updated");
        }
    }
}
