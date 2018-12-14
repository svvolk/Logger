using System;
using System.Net;
using System.Net.Http;
using Logger;
using LoggerClient.Model;

namespace LoggerClient.Services
{
    /// <summary>
    /// Сервис по работе с логами из БД
    /// </summary>
    public class DbLogService : IService
    {
        /// <summary>
        /// Получить все логи
        /// </summary>
        /// <returns></returns>
        public Log[] GetAll()
        {
            using (var client = new HttpClientWrapper())
            {
                using (var response = client.Client.GetAsync("api/DbLog").Result)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Content.ReadAsAsync<Log[]>().Result;
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

        /// <summary>
        /// Получить последнюю запись
        /// </summary>
        /// <returns></returns>
        public Log GetLast()
        {
            using (var client = new HttpClientWrapper())
            {
                using (var response = client.Client.GetAsync("api/DbLog/Last").Result)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Content.ReadAsAsync<Log>().Result;
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