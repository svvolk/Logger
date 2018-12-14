using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using NLog;

namespace LogWebServer
{
    public class Global : HttpApplication
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private Logger _defaultLogger;

        /// <summary>
        /// Тип логирования db или file
        /// </summary>
        private string _loggerType = string.Empty;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Global()
        {
            this._defaultLogger = LogManager.GetLogger(this._loggerType);
        }

        private void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            this.CheckType();

            Task.Factory.StartNew(this.RunWriteProcess);
            Task.Factory.StartNew(this.RunCheckTypeProcess);
        }

        /// <summary>
        /// Проверка типа логирования на смену
        /// </summary>
        private void RunCheckTypeProcess()
        {
            while(true)
            {
                string appSetting = ConfigurationManager.AppSettings["LoggerType"];
                if(appSetting != this._loggerType)
                {
                    this._loggerType = appSetting;
                    this._defaultLogger = LogManager.GetLogger(this._loggerType);
                }

                Thread.Sleep(10000);
            }
        }

        /// <summary>
        /// Запись лога
        /// </summary>
        private void RunWriteProcess()
        {
            while(true)
            {
                this._defaultLogger.Info(GC.GetTotalMemory(true));
                Thread.Sleep(5000);
            }
        }

        /// <summary>
        /// Проверяем, не сменился ли тип логирования
        /// Если тип поменялся, пересоздаем логгер
        /// </summary>
        private void CheckType()
        {
            string appSetting = ConfigurationManager.AppSettings["LoggerType"];
            if(appSetting != this._loggerType)
            {
                this._loggerType = appSetting;
                this._defaultLogger = LogManager.GetLogger(this._loggerType);
            }
        }
    }
}