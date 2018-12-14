using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerDataAccess.Entities
{
    /// <summary>
    /// Лог
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Идентификатор лога
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Дата и время записи лога
        /// </summary>
        public string LogDt { get; set; }

        /// <summary>
        /// Объем потребляемой памяти
        /// </summary>
        public string MemoryVolume { get; set; }
    }
}
