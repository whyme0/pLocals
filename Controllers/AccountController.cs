using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pLocals.Data;
using pLocals.Models;
using pLocals.Models.DTOs;
using pLocals.Repository;

namespace pLocals.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ProjectBaseController
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
        public ICollection<Account> Get() // ����� ��������� ��������
        {
            _logger.LogInformation("�������� ��� ������");
            return _accRepository
                .FindAll()
                .OrderByDescending(a => a.Id)
                .ToList();
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public ActionResult<Account> Get(int id)
        {
            Account? acc = _accRepository.Find(a => a.Id == id).FirstOrDefault();
            if (acc == null)
                return NotFound($"Account with id '{id}' cannot be found");
            return acc;
        }

        [HttpGet]
        [Route("get/{title}")]
        public ActionResult<List<Account>> Get(string title)
        {
            var acc = _accRepository.FindAllByTitle(title).ToList();
            
            if (acc.Count == 0)
                return NotFound($"Account with title '{title}' cannot be found");
            
            return acc;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] CreateAccountDTO account) // ����� ��������� �� ��������
        {
            if (_accRepository.IsTitleExists(account.Title))
            {
                ModelState.AddModelError("Title", "This title already exists, please try another");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Account a = new Account() { 
                Title = account.Title,
                Login = account.Login,
                Password = account.Password,
                NoteText = account.NoteText
            };

            _accRepository.Create(a);
            
            await _context.SaveChangesAsync();
            
            return Created();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Account? a = _accRepository.Find(a => a.Id == id).FirstOrDefault();

            if (a == null)
                return NotFound();
           
            _accRepository.Delete(a);
            
            await _context.SaveChangesAsync();
            
            return Accepted("Account successfully deleted");
        }

        [HttpPut]
        [Route("update/{id}")]
        [Consumes("application/json")]
        public ActionResult Update(int id, [FromBody] UpdateAccountDTO accountDTO)
        {
            Account? a = _accRepository.Find(a => a.Id == id).FirstOrDefault();

            if (a == null)
            {
                return NotFound();
            }
            if (accountDTO.Title == "" || _accRepository.IsTitleExists(accountDTO.Title))
            {
                ModelState.AddModelError("Errors", "This title already exists, please try another");
            }
            if (accountDTO.Login == "")
            {
                ModelState.AddModelError("Errors", "Login cannot be empty");
            }
            if (accountDTO.Password == "")
            {
                ModelState.AddModelError("Errors", "Password cannot be empty");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (accountDTO.Title != null)
            {
                a.Title = accountDTO.Title;
                a.NormalizedTitle = accountDTO.Title.ToLower();
            }
            if (accountDTO.Login != null) a.Login = accountDTO.Login;
            if (accountDTO.Password != null) a.Password = accountDTO.Password;
            if (accountDTO.NoteText != null) a.NoteText = accountDTO.NoteText;

            _accRepository.Update(a);

            _context.SaveChanges();

            return Ok("Updated");
        }
    }
}
