using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_WebSiteMVC_Pipeline.DAL.Interfaces;
using Task_WebSiteMVC_Pipeline.Domain.Entity;

namespace Task_WebSiteMVC_Pipeline.DAL.Repositories
{
    public class TaskRepository : IBaseRepository<TaskEntity>
    {
        private readonly AppDBContext _dbContext;
 
    
    public TaskRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(TaskEntity entity)
    {
        await _dbContext.TaskEntities.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(TaskEntity entity)
    {
        _dbContext.TaskEntities.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public IQueryable<TaskEntity> GetAll()
    {
        return _dbContext.TaskEntities;
    }

    public async Task<TaskEntity> Update(TaskEntity entity)
    {
        _dbContext.TaskEntities.Update(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }
}
}
