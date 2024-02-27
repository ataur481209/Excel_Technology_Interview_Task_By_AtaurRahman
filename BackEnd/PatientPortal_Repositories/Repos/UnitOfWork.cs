using DatabaseModels.DatabaseContext;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly PatientInfoPortalDbContext db;
        public UnitOfWork(PatientInfoPortalDbContext db)
        {
            this.db = db;
        }

        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.db.Dispose();
        }

        public IGenericRepo<T> GetRepo<T>() where T : class
        {
            return new GenericRepo<T>(this.db);
        }
    }
}
