using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using LoggerDataAccess.Entities;
using LoggerDataAccess.Repositories;

namespace LogWebServer.Controllers
{
    public class DbLogController : ApiController
    {
        /// <summary>
        /// Репозиторий для работы с логами
        /// </summary>
        private readonly LogRepository _repository = new LogRepository();

        /// <summary>
        /// Возвращает все логи
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(IEnumerable<Log>))]
        public IHttpActionResult Get()
        {
            var logs = this._repository.GetAll();
            return this.Ok(logs);
        }

        /// <summary>
        /// Возвращает последнюю запись
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Log))]
        [Route("api/DbLog/Last")]
        public IHttpActionResult Last()
        {
            var log = this._repository.GetLast();
            return this.Ok(log);
        }
    }
}