using pLocals.Repository.Abstract;
using pLocals.Models;
using pLocals.Data;

namespace pLocals.Repository
{
    public class AccountRepository : RepositoryBase<Account>
    {
        public AccountRepository(AppDbContext context) : base(context)
        {
        }
    }
}
