using System;

namespace LoggerClient.Model
{
    /// <summary>
    /// Лог
    /// </summary>
    public class Log : IEquatable<Log>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата и время записи лога
        /// </summary>
        public string LogDt { get; set; }

        /// <summary>
        /// Используемая память
        /// </summary>
        public string MemoryVolume { get; set; }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Log other)
        {
            return (this.Id == other.Id) &&
                   (this.LogDt == other.LogDt) &&
                   (this.MemoryVolume == other.MemoryVolume);
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return "Дата: " + this.LogDt + " Объем памяти: " + this.MemoryVolume + " байт" + "\r\n";
        }
    }
}