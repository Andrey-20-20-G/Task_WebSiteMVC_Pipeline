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
    }
}
