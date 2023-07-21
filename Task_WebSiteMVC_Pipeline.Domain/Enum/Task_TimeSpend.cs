using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_WebSiteMVC_Pipeline.Domain.Enum
{
    public enum Task_TimeSpend
    {
        [Display(Name ="Краткосрочная (В пределах 2-3х рабочих дней)")]
        Fast = 1,
        [Display(Name = "Средняя по продолжительности (Не более 2-3х недель)")]
        Normal = 2,
        [Display(Name = "Долгосрочная (Более месяца)")]
        LongTime = 3
    }
}
