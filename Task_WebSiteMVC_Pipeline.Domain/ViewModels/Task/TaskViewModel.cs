using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_WebSiteMVC_Pipeline.Domain.Enum;

namespace Task_WebSiteMVC_Pipeline.Domain.ViewModels.Task
{
    public class TaskViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; } = String.Empty;

        [Display(Name = "Описание")]
        public string Description { get; set; } = String.Empty;

        [Display(Name = "Дата создания")]
        public string CreatedDate { get; set; }
        [Display(Name = "Статус выполнения")]
        public string IsDone { get; set; }
        [Display(Name = "Тип задачи")]
        public string Type { get; set; }
    }
}
