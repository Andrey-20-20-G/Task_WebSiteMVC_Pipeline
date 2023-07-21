using Microsoft.Extensions.Logging;
using Task_WebSiteMVC_Pipeline.Domain.Entity;
using Task_WebSiteMVC_Pipeline.Domain.Response;
using Task_WebSiteMVC_Pipeline.Domain.ViewModels.Task;
using Task_WebSiteMVC_Pipeline.Service.Interfaces;
using Task_WebSiteMVC_Pipeline.Domain.Enum;
using Task_WebSiteMVC_Pipeline.Domain.Interfaces;

namespace Task_WebSiteMVC_Pipeline.Service.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly DAL.Interfaces.IBaseRepository<TaskEntity> _repository;
        private ILogger<TaskService> _logger;

        public TaskService(DAL.Interfaces.IBaseRepository<TaskEntity> repository, 
            ILogger<TaskService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IBaseRepository<TaskEntity>> CreateTask(CreateTaskViewModel model)
        {
            try
            {
                _logger.LogInformation($"Запрос на создание задачи - {model.Name}");

                var task = _repository.GetAll()
                    .Where(x => x.CreatedDate.Date == DateTime.Today)
                    .FirstOrDefault(x => x.Name == model.Name);
                if (task != null)
                {
                    return new BaseResponse<TaskEntity>()
                    {
                        Description = "Задача с таким названием уже существует",
                        StatusCode = StatusCode.YouAlreadyHave
                    };
                }
                else
                {
                    task = new TaskEntity()
                    {
                        Name = model.Name,
                        IsDone = false,
                        CreatedDate = DateTime.Now,
                        Type = model.Type,
                        Description = model.Description,
                    };
                    await _repository.Create(task);

                    _logger.LogInformation($"Задача была успешно добавлена {task.Name}, {task.CreatedDate}");

                    return new BaseResponse<TaskEntity>()
                    {
                        Description = "Задача успешно добавлена",
                        StatusCode = StatusCode.Success
                    };
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[TaskService.CreateTask]: {ex.Message}");
                return new BaseResponse<TaskEntity>()
                {
                    StatusCode = StatusCode.ServerError
                };
            }
        }
    }
}
