using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_WebSiteMVC_Pipeline.Domain.Entity;
using Task_WebSiteMVC_Pipeline.Domain.Interfaces;
using Task_WebSiteMVC_Pipeline.Domain.ViewModels.Task;

namespace Task_WebSiteMVC_Pipeline.Service.Interfaces
{
    public interface ITaskService
    {
        public Task<IBaseRepository<TaskEntity>> CreateTask(CreateTaskViewModel model);
    }
}
