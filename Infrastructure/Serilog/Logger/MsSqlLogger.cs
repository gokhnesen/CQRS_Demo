using Infrastructure.Serilog.ConfigurationModels;
using Infrastructure.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Serilog.Logger
{
    public class MsSqlLogger:LoggerServiceBase
    {

        public MsSqlLogger(IConfiguration configuration)
        {
            MsSqlConfiguration logConfiguration = configuration.GetSection("SerilogConfigurations:MsSqlConfiguration").Get<MsSqlConfiguration>()
                ?? throw new Exception(SerilogMessages.NullOptionsMessage);

            MSSqlServerSinkOptions sinkOptions = new()
            {
                TableName = logConfiguration.TableName, AutoCreateSqlDatabase = logConfiguration.AutoCreateSqlTable
            };

            ColumnOptions columnOptions = new();

            global::Serilog.Core.Logger serilogConfig = new LoggerConfiguration().WriteTo.MSSqlServer(logConfiguration.ConnectionString,sinkOptions,columnOptions:columnOptions)
                .CreateLogger();
            Logger = serilogConfig;
        }
        
    }
}
