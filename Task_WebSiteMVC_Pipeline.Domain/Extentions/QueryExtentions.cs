using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task_WebSiteMVC_Pipeline.Domain.Extentions
{
    public static class QueryExtentions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, 
            bool condition, Expression<Func<T, bool>> predicate)
        {
            if(condition)
                return source.Where(predicate);
            
            return source;
        }
    }
}
