using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using LoggerDataAccess.Repositories;

namespace LogWcfService
{
    public class Service1 : IService
    {
        /// <summary>
        /// Репозиторий для работы с логами
        /// </summary>
        private readonly LogRepository _repository = new LogRepository();

        /// <summary>
        /// Тип логирования
        /// </summary>
        private string _currentType = string.Empty;

        /// <summary>
        /// Web Api Base address
        /// </summary>
        private Uri apiBaseUri = new Uri(ConfigurationManager.AppSettings["WebService"]);

        /// <summary>
        /// Получить информацию о том, куда в настоящий момент осуществляется логирование
        /// </summary>
        /// <returns></returns>
        public string GetCurrentLoggerTypeAsync()
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = this.apiBaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using(var response = client.GetAsync("api/Type").Result)
                {
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        this._currentType = response.Content.ReadAsAsync<string>().Result;
                    }
                    else
                    {
                        throw new HttpRequestException(response.Content.ReadAsStringAsync().Result);
                    }
                }
            }

            return this._currentType;
        }

        /// <summary>
        /// Получить все логи по одному типу
        /// </summary>
        /// <returns></returns>
        public Log[] GetData()
        {
            if(this._currentType == "База данных")
            {
                return this.GetFromDb();
            }

            if(this._currentType == "Файловое хранилище")
            {
                return this.GetFromFile();
            }

            return null;
        }

        /// <summary>
        /// Получить из базы
        /// </summary>
        /// <returns></returns>
        private Log[] GetFromDb()
        {
            List<Log> result = new List<Log>();
            LoggerDataAccess.Entities.Log[] logs = this._repository.GetAll();
            foreach(LoggerDataAccess.Entities.Log log in logs)
            {
                result.Add(this.TranslateLogEntityToLog(log));
            }

            return result.ToArray();
        }

        /// <summary>
        /// Получить из файла
        /// </summary>
        /// <returns></returns>
        private Log[] GetFromFile()
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = this.apiBaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using(var response = client.GetAsync("api/FileLog").Result)
                {
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        var arr = response.Content.ReadAsAsync<Log[]>().Result;

                        return arr;
                    }

                    throw new HttpRequestException(response.Content.ReadAsStringAsync().Result);
                }
            }
        }

        /// <summary>
        /// Привести экземпляр лога из EF к контракту WCF
        /// </summary>
        /// <param name="logEntity"></param>
        /// <returns></returns>
        private Log TranslateLogEntityToLog(LoggerDataAccess.Entities.Log logEntity)
        {
            Log log = new Log();
            log.Id = logEntity.Id;
            log.LogDt = logEntity.LogDt;
            log.StringValue = logEntity.MemoryVolume;
            return log;
        }
    }
}