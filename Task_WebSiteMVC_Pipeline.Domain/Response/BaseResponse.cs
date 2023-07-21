using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_WebSiteMVC_Pipeline.Domain.Enum;
using Task_WebSiteMVC_Pipeline.Domain.Interfaces;

namespace Task_WebSiteMVC_Pipeline.Domain.Response
{
    public class BaseResponse<T> : IBaseRepository<T>
    {
        public string Description { get; set; }

        public StatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }
}
