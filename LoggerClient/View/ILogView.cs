using System;

namespace LoggerClient.View
{
    /// <summary>
    /// Интерфейс, описывающий форму логов
    /// </summary>
    public interface ILogView
    {
        /// <summary>
        /// Тип логирования для просмотра логов
        /// </summary>
        LoggingType LoggingType { get; set; }

        /// <summary>
        /// Текущий тип логирования
        /// </summary>
        string CurrentLoggingType { set; }

        /// <summary>
        /// Загрузить логи
        /// </summary>
        /// <param name="logs"></param>
        void LoadLogs(string logs);

        /// <summary>
        /// Добавить последнюю запись в вывод
        /// </summary>
        /// <param name="log"></param>
        void AppendLog(string log);

        /// <summary>
        /// Изменение выбранного типа логирования
        /// </summary>
        event Action LogTypeChanged;
    }
}