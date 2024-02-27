using DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAllData();
        //Task<IQueryable<T>> GetAllData();
        Task<T> GetDataById(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllDataById(Expression<Func<T, bool>> predicate);
        Task InsertData(T data);
        Task UpdateData(T data);
        Task DeleteData(T data);
        Task DeleteData(IEnumerable<T> data);
    }
}
