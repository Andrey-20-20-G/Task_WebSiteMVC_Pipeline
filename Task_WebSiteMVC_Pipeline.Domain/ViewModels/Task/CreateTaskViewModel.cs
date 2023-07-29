using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_WebSiteMVC_Pipeline.Domain.Enum;

namespace Task_WebSiteMVC_Pipeline.Domain.ViewModels.Task
{
    public class CreateTaskViewModel
    {
        public string Name { get; set; } 
        public string Description { get; set; }
        public Task_TimeSpend Type { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentNullException(Name, "Укажите название задачи");
            }
            if (string.IsNullOrWhiteSpace(Description))
            {
                throw new ArgumentNullException(Description, "Укажите описание задачи");
            }
        }
    }
}
