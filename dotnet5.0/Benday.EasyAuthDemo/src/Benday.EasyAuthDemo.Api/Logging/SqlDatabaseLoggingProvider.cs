using System;
using System.Collections.Concurrent;
using Benday.EasyAuthDemo.Api.DataAccess;
using Benday.EasyAuthDemo.Api.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Benday.EasyAuthDemo.Api.Logging
{
    public class SqlDatabaseLoggerProvider : IDisposable, ILoggerProvider, ISupportExternalScope
    {
        public SqlDatabaseLoggerProvider(
            SqlDatabaseLoggerOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), "Argument cannot be null.");
            }
            
            _Options = options;
        }
        
        ~SqlDatabaseLoggerProvider()
        {
            if (!this.IsDisposed)
            {
                Dispose(false);
            }
        }
        
        ConcurrentDictionary<string, SqlDatabaseLogger> loggers =
        new ConcurrentDictionary<string, SqlDatabaseLogger>();
        private IExternalScopeProvider _ScopeProvider;
        protected IDisposable _SettingsOnChangeIDisposable;
        
        void ISupportExternalScope.SetScopeProvider(IExternalScopeProvider scopeProvider)
        {
            _ScopeProvider = scopeProvider;
        }
        
        ILogger ILoggerProvider.CreateLogger(string category)
        {
            return loggers.GetOrAdd(category,
            (category) => {
            return new SqlDatabaseLogger(this, category);
        });
    }
    
    void IDisposable.Dispose()
    {
        if (!this.IsDisposed)
        {
            try
            {
                Dispose(true);
            }
            catch
            {
            }
            
            this.IsDisposed = true;
            GC.SuppressFinalize(this);  // instructs GC not bother to call the destructor
        }
    }
    
        protected virtual void Dispose(bool disposing)
        {
            if (_SettingsOnChangeIDisposable != null)
            {
                _SettingsOnChangeIDisposable.Dispose();
                _SettingsOnChangeIDisposable = null;
            }
        }
        
        internal SqlDatabaseLoggerOptions _Options { get; private set; }
        
        public bool IsEnabled(LogLevel logLevel)
        {
            bool Result = logLevel != LogLevel.None &&
            _Options.LogLevel != LogLevel.None &&
            Convert.ToInt32(logLevel) >= Convert.ToInt32(_Options.LogLevel);
            
            return Result;
        }
        
        internal IExternalScopeProvider ScopeProvider
        {
            get
            {
                if (_ScopeProvider == null)
                _ScopeProvider = new LoggerExternalScopeProvider();
                return _ScopeProvider;
            }
        }
        
        public bool IsDisposed { get; protected set; }
    }
}
