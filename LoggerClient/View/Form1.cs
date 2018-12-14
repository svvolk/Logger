using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LoggerClient.Presenter;

namespace LoggerClient.View
{
    public partial class Form1 : Form, ILogView
    {
        public Form1()
        {
            this.InitializeComponent();
            this.InitLookUpTypes();
            LogPresenter presenter = new LogPresenter(this);
            this._txtLoggingType.EditValueChanged += (s, a) => this.LogTypeChanged?.Invoke();
        }

        /// <summary>
        /// Текущий тип логирования
        /// </summary>
        public LoggingType LoggingType
        {
            get { return (LoggingType)this._txtLoggingType.EditValue; }
            set { this._txtLoggingType.EditValue = value; }
        }

        /// <summary>
        /// Текущий тип логирования
        /// </summary>
        public string CurrentLoggingType
        {
            set { this._txtCurrentType.Text = value; }
        }

        /// <summary>
        /// Загрузить логи
        /// </summary>
        /// <param name="logs"></param>
        public void LoadLogs(string logs)
        {
            this._memoEdit.Text = string.Empty;
            this._memoEdit.Text = logs;
        }

        /// <summary>
        /// Добавить последнюю запись в вывод
        /// </summary>
        /// <param name="log"></param>
        public void AppendLog(string log)
        {
            var text = this._memoEdit.Text;
            this._memoEdit.Text = log + text;
        }

        /// <summary>
        /// Изменение выбранного типа логирования
        /// </summary>
        public event Action LogTypeChanged;

        /// <summary>
        /// Инициализация выпадающего списка типов логирования
        /// </summary>
        public void InitLookUpTypes()
        {
            this._txtLoggingType.Properties.ShowHeader = false;
            this._txtLoggingType.Properties.ShowFooter = false;
            this._txtLoggingType.Properties.DisplayMember = "Value";
            this._txtLoggingType.Properties.ValueMember = "Key";

            this._txtLoggingType.Properties.DataSource = new Dictionary<LoggingType, string>
            {
                { LoggingType.DB, "База данных" },
                { LoggingType.File, "Файловое хранилище" }
            };

            this._txtLoggingType.EditValue = LoggingType.DB;
        }
    }

    /// <summary>
    /// Тип логирования
    /// </summary>
    public enum LoggingType
    {
        /// <summary>
        /// База данных
        /// </summary>
        DB = 0,

        /// <summary>
        /// Файловое хранилище
        /// </summary>
        File = 1
    }
}
