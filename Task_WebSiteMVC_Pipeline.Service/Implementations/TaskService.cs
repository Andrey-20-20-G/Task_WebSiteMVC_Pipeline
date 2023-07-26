using Microsoft.Extensions.Logging;
using Task_WebSiteMVC_Pipeline.Domain.Entity;
using Task_WebSiteMVC_Pipeline.Domain.Response;
using Task_WebSiteMVC_Pipeline.Domain.ViewModels.Task;
using Task_WebSiteMVC_Pipeline.Service.Interfaces;
using Task_WebSiteMVC_Pipeline.Domain.Enum;
using Task_WebSiteMVC_Pipeline.Domain.Interfaces;
using Task_WebSiteMVC_Pipeline.Extentions;
using Microsoft.EntityFrameworkCore;
using Task_WebSiteMVC_Pipeline.Domain.Filters.Task;
using Task_WebSiteMVC_Pipeline.Domain.Extentions;

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

        public async Task<IBaseRepository<bool>> CloseTask(long id)
        {
            try
            {
                var task = await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (task == null) 
                {
                    return new BaseResponse<bool>()
                    {
                        Description = $"Задача не найдена",
                        StatusCode = StatusCode.TaskNotFound
                    };
                }
                task.IsDone = true;
                await _repository.Update(task);
                return new BaseResponse<bool>()
                {
                    Description = $"Задача успешно закрыта",
                    StatusCode = StatusCode.Success
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[TaskService.EndTask]: {ex.Message}");
                return new BaseResponse<bool>()
                {
                    Description = $"{ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IBaseRepository<TaskEntity>> CreateTask(CreateTaskViewModel model)
        {
            try
            {
                model.Validate();
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
                    Description = $"{ ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IBaseRepository<IEnumerable<TaskViewModel>>> GetTask(TaskFilter taskFilter)
        {
            try
            {
                var task = await _repository.GetAll()
                    .Where(x => !x.IsDone)
                    .WhereIf(!string.IsNullOrWhiteSpace(taskFilter.Name), x => x.Name == taskFilter.Name)
                    .WhereIf(taskFilter.TimeSpend.HasValue, x => x.Type == taskFilter.TimeSpend)
                    .Select(x => new TaskViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        IsDone = x.IsDone == true ? "Готова" : "Не готова",
                        Type= x.Type.GetDisplayName(),
                        CreatedDate = x.CreatedDate.ToLongDateString()
                    })
                    .ToListAsync();

                return new BaseResponse<IEnumerable<TaskViewModel>>()
                {
                    Data = task,
                    StatusCode = StatusCode.Success
                };
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"[TaskService.CreateTask]: {ex.Message}");
                return new BaseResponse<IEnumerable<TaskViewModel>>()
                {
                    Description = $"{ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }
    }
}
