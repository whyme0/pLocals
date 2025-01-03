﻿using pLocals.Repository.Abstract;
using pLocals.Models;
using pLocals.Data;
using System.Linq.Expressions;

namespace pLocals.Repository
{
    public class AccountRepository : RepositoryBase<Account>
    {
        public AccountRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Account> FindAllByTitle(string title)
        {
            return Find(a => a.NormalizedTitle.Contains(title.ToLower())).ToList();
        }

        public Account? FindByTitle(string title)
        {
            return Find(a => a.NormalizedTitle == title.ToLower()).FirstOrDefault();
        }

        public override void Create(Account entity)
        {
            entity.NormalizedTitle = entity.Title.ToLower();
            base.Create(entity);
        }

        public bool IsTitleExists(string? title)
        {
            return title != null && FindByTitle(title) != null;
        }
    }
}
