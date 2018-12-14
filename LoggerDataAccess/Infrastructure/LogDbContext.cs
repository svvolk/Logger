using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerDataAccess.Entities;

namespace LoggerDataAccess.Infrastructure
{
    public class LogDbContext: DbContext
    {
        /// <summary>
        /// Статический конструктор
        /// </summary>
        static LogDbContext()
        {
            Database.SetInitializer<LogDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // наименование таблицы в ед. числе
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Логи
        /// </summary>
        public DbSet<Log> Logs { get; set; }
    }
}
