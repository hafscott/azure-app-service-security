using System;
using Benday.EasyAuthDemo.Api.DataAccess;
using Benday.EasyAuthDemo.Api.DataAccess.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Benday.EasyAuthDemo.Api.Logging
{
    public class SqlDatabaseLogger : ILogger
    {
        private string _ConnectionString;
        
        public SqlDatabaseLogger(SqlDatabaseLoggerProvider provider, string category)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider), "Argument cannot be null.");
            }
            
            if (provider._Options == null ||
            String.IsNullOrEmpty(provider._Options.ConnectionString) == true)
            {
                throw new ArgumentNullException(
                nameof(provider),
                "Settings are null or connection string is not set.");
            }
            else
            {
                _ConnectionString = provider._Options.ConnectionString;
            }
            
            this.Provider = provider;
            this.Category = category;
        }
        
        IDisposable ILogger.BeginScope<TState>(TState state)
        {
            return Provider.ScopeProvider.Push(state);
        }
        
        bool ILogger.IsEnabled(LogLevel logLevel)
        {
            return Provider.IsEnabled(logLevel);
        }
        
        void ILogger.Log<TState>(LogLevel logLevel, EventId eventId,
        TState state, Exception exception,
        Func<TState, Exception, string> formatter)
        {
            if ((this as ILogger).IsEnabled(logLevel))
            {
                var logItem = new LogEntryEntity();
                
                logItem.Category = this.Category;
                logItem.LogLevel = logLevel.ToString();
                
                logItem.LogText = exception?.Message ?? state.ToString();
                logItem.ExceptionText = exception == null ? "" : exception.ToString();
                logItem.EventId = eventId.ToString();
                logItem.State = state == null ? state.ToString() : "unknown-state";
                
                SaveToDatabase(logItem);
            }
        }
        
        private void SaveToDatabase(LogEntryEntity item)
        {
            using (var connection = new SqlConnection(_ConnectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                    "INSERT INTO LogEntry (" +
                    "Category, LogLevel, LogText, ExceptionText, EventId, State, LogDate) " +
                    "VALUES (" +
                    "@Category, @LogLevel, @LogText, @ExceptionText, @EventId, @State, GETUTCDATE())";
                    
                    command.Parameters.AddWithValue("@Category", item.Category);
                    command.Parameters.AddWithValue("@LogLevel", item.LogLevel);
                    command.Parameters.AddWithValue("@LogText", item.LogText);
                    command.Parameters.AddWithValue("@ExceptionText", item.ExceptionText);
                    command.Parameters.AddWithValue("@EventId", item.EventId);
                    command.Parameters.AddWithValue("@State", item.State);
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public SqlDatabaseLoggerProvider Provider { get; private set; }
        public string Category { get; private set; }
    }
}
