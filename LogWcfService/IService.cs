using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace LogWcfService
{
    /// <summary>
    /// Описание интерфейса сервиса
    /// </summary>
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string GetCurrentLoggerTypeAsync();

        [OperationContract]
        Log[] GetData();
    }


    [DataContract]
    public class Log
    {
        private string logDt = string.Empty;
        private string memory = string.Empty;

        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        public string LogDt
        {
            get { return this.logDt; }
            set { this.logDt = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return this.memory; }
            set { this.memory = value; }
        }
    }
}