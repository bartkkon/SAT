using Microsoft.EntityFrameworkCore;
using Saving_Accelerator_Tool.Connection;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Data
{
    class DataBaseConnectionContext : DbContext
    {
        public DbSet<UserDB> Users { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.connectionString);
        }
    }
}
