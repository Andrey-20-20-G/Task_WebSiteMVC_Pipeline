using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_WebSiteMVC_Pipeline.Domain.Enum;

namespace Task_WebSiteMVC_Pipeline.Domain.Entity
{
    public class TaskEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; }
        public bool IsDone { get; set; }
        public Task_TimeSpend Type { get; set; }

    }
}
