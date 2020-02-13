﻿
using Data.Contexts;
using Data.Entities.Credit;
using Data.Entities.Debit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Accouting.DataAccessLayer
{
    public class SafeDAL : ISafeDAL
    {
        private AppDbContext _context;
        private DbSet<Safe> _entity;

        public SafeDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<Safe>();
        }

        public async Task<long> Save(Safe entity)
        {
            _context.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            Safe farm = await GetById(id);
            _context.Safes.Remove(farm);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<Safe>> GetAll()
        {
            return await _context.Safes.ToListAsync();
        }

        public async Task<Safe> GetById(long id)
        {
            return await _context.Safes.SingleOrDefaultAsync(x => x.Id == id);
        }

    }
}
