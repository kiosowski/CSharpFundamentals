﻿using Logger.Models.Appenders.Contracts;
using Logger.Models.Appenders.Enums;
using Logger.Models.Loggers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Loggers
{
    public class LoggerClass : ILogger
    {
        private IList<IAppender> appenders;
        public LoggerClass(params IAppender[] appenders)
        {
            this.appenders = new List<IAppender>();
            foreach (var appender in appenders)
            {
                this.appenders.Add(appender);
            }
        }
        public void Error(string time, string message)
        {
            this.LogMessage(time, ReportLevel.Error, message);
        }
        public void Info(string time, string message)
        {
            this.LogMessage(time, ReportLevel.Info, message);
        }
        public void Warning(string time, string message)
        {
            this.LogMessage(time, ReportLevel.Warning, message);
        }
        public void Fatal(string time, string message)
        {
            this.LogMessage(time, ReportLevel.Fatal, message);
        }
        public void Critical(string time, string message)
        {
            this.LogMessage(time, ReportLevel.Critical, message);
        }
        public void PrintLoggerInfo()
        {
            Console.WriteLine("Logger info");
            foreach (var appender in this.appenders)
            {
                Console.WriteLine(appender);
            }
        }
        private void LogMessage(string time,ReportLevel reportLevel,string message)
        {
            foreach (var appender in this.appenders)
            {
                appender.AppendLine(time, reportLevel, message);
            }
        }


    }
}
