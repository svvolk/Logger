using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogWebServer.Models
{
    public class LogEntry
    {
        public int Id { get; set; }
        public string LogDt { get; set; }
        public string MemoryVolume { get; set; }
    }
}