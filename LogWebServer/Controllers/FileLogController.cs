using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;
using LoggerDataAccess.Entities;


namespace LogWebServer.Controllers
{
    public class FileLogController : ApiController
    {
        /// <summary>
        /// Файл с логами
        /// </summary>
        private readonly string _file = $"{AppDomain.CurrentDomain.BaseDirectory}/Logs/Log.txt";

        /// <summary>
        /// Возвращает все логи
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(Log[]))]
        public IHttpActionResult Get()
        {
            while (!File.Exists(this._file))
            {
                Thread.Sleep(1000);
            }

            List<Log> logs = new List<Log>();
            string[] lines = File.ReadLines(this._file).Reverse().ToArray();

            foreach (var line in lines)
            {
                var tempArr = line.Split('\t');
                Log l = new Log();
                l.LogDt = tempArr[0];
                l.MemoryVolume = tempArr[1];
                logs.Add(l);
            }
            //string result = string.Concat(lines);
            return this.Ok(logs);
        }

        /// <summary>
        /// Возвращает последнюю запись
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Log))]
        [Route("api/FileLog/Last")]
        public IHttpActionResult Last()
        {
            string[] lines = File.ReadLines(this._file).ToArray();
            string lastLine = lines.LastOrDefault();

            var tempArr = lastLine.Split('\t');
            Log l = new Log();
            l.LogDt = tempArr[0];
            l.MemoryVolume = tempArr[1];
            return this.Ok(l);
        }

    }
}