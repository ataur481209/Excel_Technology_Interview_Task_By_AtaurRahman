using DatabaseModels.DatabaseContext;
using DatabaseModels.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly PatientInfoPortalDbContext db;
        private readonly DbSet<T> dbset;

        public GenericRepo(PatientInfoPortalDbContext db)
        {
            this.db = db;
            dbset = this.db.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllData()
        {
            return await dbset.ToListAsync();
        }

        //public IQueryable<T> GetAllData()
        //{
        //    return dbset.AsQueryable();
        //}


        //public async Task<T> GetDataById(Expression<Func<T, bool>> predicate)
        //{
        //    return await dbset.AsQueryable().FirstAsync(predicate);
        //}

        public async Task<T> GetDataById(Expression<Func<T, bool>> predicate)
        {
            return await dbset.AsQueryable().FirstOrDefaultAsync(predicate);
        }


        public async Task<IEnumerable<T>> GetAllDataById(Expression<Func<T, bool>> predicate)
        {
            return await dbset.AsQueryable().Where(predicate).ToListAsync();
        }

        public async Task InsertData(T data)
        {
            await dbset.AddAsync(data);
        }

        public Task UpdateData(T data)
        {
            this.db.Entry(data).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task DeleteData(T data)
        {
            var result = this.db.Remove(data);
            await Task.FromResult(result);
        }

        public async Task DeleteData(IEnumerable<T> data)
        {
            db.RemoveRange(data);
            await Task.CompletedTask;
        }

        
    }
}
