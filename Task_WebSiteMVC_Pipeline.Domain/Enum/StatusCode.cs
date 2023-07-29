using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_WebSiteMVC_Pipeline.Domain.Enum
{
    public enum StatusCode
    {
        YouAlreadyHave = 1,
        TaskNotFound = 4,
        Success = 200,
        ServerError = 500,
    }
}
