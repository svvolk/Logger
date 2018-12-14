using System.Collections.Generic;
using LoggerClient.Model;

namespace LoggerClient.Services
{
    /// <summary>
    /// Интерфейс сервиса по работе с логами
    /// </summary>
    public interface IService
    {
        Log[] GetAll();
        Log GetLast();
    }

    /// <summary>
    /// Класс сервиса, реализующий стратегию
    /// </summary>
    public class Service
    {
        public IService LogService;
        public Service(IService service)
        {
            this.LogService = service;
        }

        public IEnumerable<Log> GetAll()
        {
            return this.LogService.GetAll();
        }

        public Log GetLast()
        {
            return this.LogService.GetLast();
        }
    }
}