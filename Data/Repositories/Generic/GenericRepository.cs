using Data.Context;
using Domain.Base;
using Domain.Entities;
using Domain.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySqlContext _context;
        private DbSet<T> dataset;
        public GenericRepository(MySqlContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }
        public async Task<T> Create(T item)
        {

            try
            {
                dataset.Add(item);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            return item;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var result = await dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null) return false;
                dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ICollection<T>> FindAll()
        {
            List<T> item = await dataset.ToListAsync();
            return item;
        }

        public async Task<T> FindById(int id)
        {
            var result = await dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            return result;
        }
        public async Task<T> Update(T item)
        {
            dataset.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}

