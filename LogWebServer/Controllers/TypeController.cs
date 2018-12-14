using System.Configuration;
using System.Web.Http;
using System.Web.Http.Description;

namespace LogWebServer.Controllers
{
    public class TypeController : ApiController
    {
        /// <summary>
        /// Возвращает текущий тип логирования из конфига сервера
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(string))]
        public IHttpActionResult Get()
        {
            string type = string.Empty;
            string appSetting = ConfigurationManager.AppSettings["LoggerType"];
            switch(appSetting)
            {
                case "db":
                    type = "База данных";
                    break;
                case "file":
                    type = "Файловое хранилище";
                    break;
            }

            return this.Ok(type);
        }
    }
}