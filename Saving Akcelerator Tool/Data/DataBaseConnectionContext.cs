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
        public DbSet<ANCMonthlyDB> ANCMonthly { get; set; }
        public DbSet<ANCRevisionDB> ANCRevision { get; set; }
        public DbSet<PNCMonthlyDB> PNCMonthly { get; set; }
        public DbSet<PNCRevisionDB> PNCRevision { get; set; }
        public DbSet<STKDB> STK { get; set; }
        public DbSet<Targets_CoinsDB> Targets_Coins { get; set; }
        public DbSet<FrozenDB> Frozen { get; set; }
        public DbSet<SumQuantityDB> SumQuantity { get; set; }
        public DbSet<SumRevisionQuantityDB> SumRevisionQuantity { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.connectionString);
        }
    }
}
