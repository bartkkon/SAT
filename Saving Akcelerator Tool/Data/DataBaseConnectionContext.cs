using Microsoft.EntityFrameworkCore;
using Saving_Accelerator_Tool.Connection;
using Saving_Accelerator_Tool.Model;
using Saving_Accelerator_Tool.Model.Action;
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
        public DbSet<ActionDB> Action { get; set; }

        //Pochodne do Action 
        public DbSet<ANCChangeDB> ANCChange { get; set; }
        public DbSet<CalculationMassDB> CalculationMass { get; set; }
        public DbSet<PNCListDB> PNCList { get; set; }
        public DbSet<PNCSpecialDB> PNCSpecial { get; set; }
        public DbSet<BU_DB> BU { get; set; }
        public DbSet<EA1_DB> EA1 { get; set; }
        public DbSet<EA2_DB> EA2 { get; set; }
        public DbSet<EA3_DB> EA3 { get; set; }
        public DbSet<EA4_DB> EA4 { get; set; }
        public DbSet<BU_Carry_DB> BU_Carry { get; set; }
        public DbSet<EA1_Carry_DB> EA1_Carry { get; set; }
        public DbSet<EA2_Carry_DB> EA2_Carry { get; set; }
        public DbSet<EA3_Carry_DB> EA3_Carry { get; set; }
        public DbSet<EA4_Carry_DB> EA4_Carry { get; set; }


        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.connectionString);
        }
    }
}
