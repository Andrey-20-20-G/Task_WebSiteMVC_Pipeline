using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_WebSiteMVC_Pipeline.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);
        Task Delete(T entity);
        IQueryable<T> GetAll();

        Task<T> Update(T entity);
    }
}
