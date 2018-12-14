using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Logger;
using LoggerClient.Model;
using LoggerClient.Services;
using LoggerClient.View;

namespace LoggerClient.Presenter
{
    public class LogPresenter
    {
        /// <summary>
        /// Контекст
        /// </summary>
        private readonly SynchronizationContext _context;

        /// <summary>
        /// Сервис логов
        /// </summary>
        private readonly Service _service;

        /// <summary>
        /// Сервис получения текущего типа логирования
        /// </summary>

        private readonly TypeService _typeService = new TypeService();

        /// <summary>
        /// Форма
        /// </summary>
        private readonly ILogView _view;

        /// <summary>
        /// Модель данных
        /// </summary>
        private List<Log> _logs = new List<Log>();

        public LogPresenter(ILogView view)
        {
            this._context = SynchronizationContext.Current;
            this._view = view;

            // событие смены типа логирования в выпадающем списке
            this._view.LogTypeChanged += this.ViewOnLogTypeChanged;

            // по умолчанию всегда загружаем логи из БД
            this._service = new Service(new DbLogService());

            this.LoadLogs();
            Task.Factory.StartNew(this.GetLoggingTypeFromServer);
            Task.Factory.StartNew(this.LoadLast);
        }

        /// <summary>
        /// Получаем с сервера текущй тип логирования
        /// </summary>
        private void GetLoggingTypeFromServer()
        {
            // и проверяем каждый 10 секунд что он не изменился
            while(true)
            {
                this._context.Post(sync => { this._view.CurrentLoggingType = this._typeService.GetCurrentType(); }, null);
                Thread.Sleep(10000);
            }
        }

        /// <summary>
        /// Изменение выбранного типа логирования
        /// </summary>
        private void ViewOnLogTypeChanged()
        {
            this.UpdateServiceStrategy();
            this.LoadLogs();
        }

        /// <summary>
        /// Загрузить логи
        /// </summary>
        private void LoadLogs()
        {
            this._logs = this._service.GetAll().ToList();

            // преобразуем массив логов в строку
            string str = string.Empty;
            foreach(Log log in this._logs)
            {
                str += log.ToString();
            }

            // отправляем на форму
            this._context.Post(sync => { this._view.LoadLogs(str); }, null);
        }

        /// <summary>
        /// Получить последнюю запись
        /// </summary>
        private void LoadLast()
        {
            while(true)
            {
                var log = this._service.GetLast();

                // если такая запись уже есть, продолжаем проверять дальше
                if(this._logs.Contains(log))
                {
                    continue;
                }

                this._context.Post(sync => { this._view.AppendLog(log.ToString()); }, null);
                Thread.Sleep(5000);
            }
        }

        /// <summary>
        /// Обновление стратегии получения логов
        /// </summary>
        private void UpdateServiceStrategy()
        {
            switch(this._view.LoggingType)
            {
                case LoggingType.DB:
                    this._service.LogService = new DbLogService();
                    break;
                case LoggingType.File:
                    this._service.LogService = new FileLogService();
                    break;
                default: break;
            }
        }
    }
}