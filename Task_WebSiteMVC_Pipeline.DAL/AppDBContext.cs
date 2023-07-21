using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_WebSiteMVC_Pipeline;
using Task_WebSiteMVC_Pipeline.Domain.Entity;

namespace Task_WebSiteMVC_Pipeline.DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
            Database.EnsureCreated();
        }

        public DbSet<TaskEntity> TaskEntities { get; set; }
    }
}