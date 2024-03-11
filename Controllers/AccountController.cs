using Microsoft.AspNetCore.Mvc;
using pLocals.Data;
using pLocals.Models;
using pLocals.Models.DTOs;
using pLocals.Repository;

namespace pLocals.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        [Route("get")]
        public ICollection<Account> Get()
        {
            return _accRepository.FindAll().ToList();
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public ActionResult<Account> Get(int id)
        {
            Account? acc = _accRepository.Find(a => a.AccountId == id).FirstOrDefault();
            if (acc == null)
                return NotFound($"Account with '{id}' id cannot be found");
            return acc;
        }

        [HttpGet]
        [Route("get/{title}")]
        public ActionResult<Account> Get(string title)
        {
            Account? acc = _accRepository.Find(a => a.Title == title).FirstOrDefault();
            if (acc == null)
                return NotFound($"Account with '{title}' title cannot be found");
            return acc;
        }

        [HttpPost]
        [Route("create")]
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
        [Route("delete/{id}")]
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
        [Route("update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] AccountDTO accountDTO)
        {
            Account? a = _accRepository.Find(a => a.AccountId == id).FirstOrDefault();
            if (a == null)
                return NotFound();
            
            _accRepository.Update(a);
            return Ok("Updated");
        }
    }
}
