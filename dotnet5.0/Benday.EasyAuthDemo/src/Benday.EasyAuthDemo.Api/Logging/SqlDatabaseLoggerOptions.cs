using Microsoft.Extensions.Logging;

namespace Benday.EasyAuthDemo.Api.Logging
{
    public class SqlDatabaseLoggerOptions
    {
        public LogLevel LogLevel { get; set; }
        public string ConnectionString { get; set; }
    }
}
