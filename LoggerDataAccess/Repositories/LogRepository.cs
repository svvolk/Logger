using System;
using System.Data.Entity.Migrations;
using System.Linq;
using LoggerDataAccess.Entities;
using LoggerDataAccess.Infrastructure;

namespace LoggerDataAccess.Repositories
{
    /// <summary>
    /// Репозиторий для работы с логами
    /// </summary>
    public class LogRepository
    {
        /// <summary>
        /// Получить все логи
        /// </summary>
        /// <returns></returns>
        public Log[] GetAll()
        {
            using(var context = new LogDbContext())
            {
                var array = context.Logs.OrderByDescending(x=>x.Id).ToArray();
                return array;
            }
        }

        /// <summary>
        /// Получить последнюю запись
        /// </summary>
        /// <returns></returns>
        public Log GetLast()
        {
            using (var context = new LogDbContext())
            {
                var log = context.Logs.OrderByDescending(p => p.Id).FirstOrDefault();
                return log;
            }
        }
    }
}