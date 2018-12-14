using System;
using System.Net;
using System.Net.Http;
using Logger;

namespace LoggerClient.Services
{
    /// <summary>
    /// Сервис получения текущего типа логирования с сервера
    /// </summary>
    public class TypeService
    {
        /// <summary>
        /// Получить текущий тип
        /// </summary>
        /// <returns></returns>
        public string GetCurrentType()
        {
            using (var client = new HttpClientWrapper())
            {
                using (var response = client.Client.GetAsync("api/Type").Result)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Content.ReadAsAsync<string>().Result;
                    }

                    var msg = $"Веб сервис возвратил ошибку c кодом: {(int)response.StatusCode}"
                              + Environment.NewLine
                              + $"Адрес: {response.RequestMessage.Method.Method} {response.RequestMessage.RequestUri}"
                              + Environment.NewLine
                              + response.Content.ReadAsStringAsync().Result;

                    throw new HttpRequestException(msg);
                }
            }
        }
    }
}