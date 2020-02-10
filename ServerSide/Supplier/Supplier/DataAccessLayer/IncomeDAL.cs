﻿
using AutoMapper;
using Data.Contexts;
using Data.Entities;
using Data.Entities.Credit;
using Microsoft.EntityFrameworkCore;
using Shared.DataAccessLayer;
using Shared.Entities.Credit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.DataAccessLayer
{
    public class IncomeDAL : IIncomeDAL
    {
        private AppDbContext _context;
        private DbSet<Income> _entity;
        private readonly IMapper _mapper;

        public IncomeDAL(AppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._entity = context.Set<Income>();
            this._mapper = mapper;
        }

        public async Task<long> Add(Income entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            Income entity = await GetById(id);
            _context.Incomes.Remove(entity);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<IncomeDTO>> GetAll()
        {
            try
            {
                return (from i in _context.Incomes
                        join c in _context.Categories on i.CategoryId equals c.Id
                        join d in _context.Drivers on i.DriverId equals d.Id
                        join f in _context.Farms on i.FarmId equals f.Id
                        join s in _context.Stations on i.StationId equals s.Id
                        select new IncomeDTO
                        {
                            Date = i.Date,
                            CartNumber = d.CarPlate,
                            CategoryId = c.Id,
                            CategoryName = c.Name,
                            FarmId = f.Id,
                            FarmName = f.OwnerName,
                            DriverId = d.Id,
                            CarPlate = d.CarPlate,
                            Quantity = i.Quantity,
                            KiloDiscount = i.KiloDiscount,
                            QuantityAfterDiscount = i.Quantity - i.KiloDiscount,
                            KiloPrice = i.KiloPrice,
                            Total = i.KiloPrice * (i.Quantity - i.KiloDiscount),
                            MoneyDiscount = i.MoneyDiscount,
                            Balance = i.Balance,
                            StationId = s.Id,
                            StationName = s.OwnerName,
                            PaidUp = i.PaidUp,
                            PaidDate = i.PaidDate,
                            RecieptNumber = i.RecieptNumber,
                        });

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Income> GetById(long id)
        {
            return await _context.Incomes.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<long> Update(Income entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<Income>> GetIncomesByFarmId(long farmId)
        {
            return await _context.Incomes.Where(x => x.FarmId == farmId).ToListAsync();
        }

        Task<IEnumerable<Income>> ICRUDOperationsDAL<Income>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
