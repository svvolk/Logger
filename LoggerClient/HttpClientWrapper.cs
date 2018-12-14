using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Logger
{
    /// <summary>
    /// Обертка над HttpClient
    /// </summary>
    public sealed class HttpClientWrapper : IDisposable
    {
        /// <summary>
        /// Создает обертку, которая обращается к настройкам базового пути WebService - ConfigurationManager.AppSettings["WebService"].
        /// </summary>
        public HttpClientWrapper() : this("WebService") {}

        /// <summary>
        /// Создает обертку, которая обращается к указанным настройкам базового пути ConfigurationManager.AppSettings[settingName].
        /// </summary>
        public HttpClientWrapper(string settingName)
        {
            this.Client = new HttpClient();
            this.Client.DefaultRequestHeaders.Accept.Clear();
            this.Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.Client.BaseAddress = new Uri(ConfigurationManager.AppSettings[settingName]);
        }

        /// <summary>
        /// HttpClient.
        /// </summary>
        public HttpClient Client { get; }

        public void Dispose()
        {
            this.Client?.Dispose();
        }
    }
}