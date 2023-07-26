using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task_WebSiteMVC_Pipeline.Domain.Filters.Task;
using Task_WebSiteMVC_Pipeline.Domain.ViewModels.Task;
using Task_WebSiteMVC_Pipeline.Service.Interfaces;

namespace Task_WebSiteMVC_Pipeline.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskViewModel model)
        {
            var response = await _taskService.CreateTask(model);
            if(response.StatusCode == Domain.Enum.StatusCode.Success)
            {
                return Ok(new {description = response.Description});
            }
            return BadRequest(new { description = response.Description });
        }

        [HttpPost]
        public async Task<IActionResult> TaskHandler(TaskFilter taskFilter)
        {
            var response = await _taskService.GetTask(taskFilter);
            return Json(new { data = response.Data});
        }
        [HttpPost]
        public async Task<IActionResult> CloseTask(long id)
        {
            var response = await _taskService.CloseTask(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Success)
            {
                return Ok(new { description = response.Description });
            }
            return BadRequest(new { description = response.Description });
        }
    }
}