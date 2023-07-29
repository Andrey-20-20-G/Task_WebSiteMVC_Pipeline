using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_WebSiteMVC_Pipeline.Domain.Entity;
using Task_WebSiteMVC_Pipeline.Domain.Filters.Task;
using Task_WebSiteMVC_Pipeline.Domain.Interfaces;
using Task_WebSiteMVC_Pipeline.Domain.ViewModels.Task;

namespace Task_WebSiteMVC_Pipeline.Service.Interfaces
{
    public interface ITaskService
    {

        Task<IBaseRepository<IEnumerable<TaskViewModel>>> CalculateCompletedTasks();
        Task<IBaseRepository<IEnumerable<TaskViewModel>>> GetCompletedTask ();

        public Task<IBaseRepository<TaskEntity>> CreateTask(CreateTaskViewModel model);

        Task<IBaseRepository<bool>> CloseTask(long id);

        Task<IBaseRepository<IEnumerable<TaskViewModel>>> GetTask(TaskFilter taskFilter);
    }
}
