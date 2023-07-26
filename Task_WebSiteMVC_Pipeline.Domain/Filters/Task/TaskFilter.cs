using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_WebSiteMVC_Pipeline.Domain.Enum;

namespace Task_WebSiteMVC_Pipeline.Domain.Filters.Task
{
    public class TaskFilter
    {
        public string Name { get; set; }
        public Task_TimeSpend? TimeSpend { get; set; }
    }
}
