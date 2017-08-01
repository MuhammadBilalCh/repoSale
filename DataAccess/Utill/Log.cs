using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace DataAccess.Utill
{
   public  class Log
    {
        private NLog.Logger _log;
        private Guid _activityId;

        public Log()
        {
            _log = LogManager.GetCurrentClassLogger();
            _activityId = Guid.NewGuid();
        }


        public string ActivityId
        {
            get { return _activityId == null ? string.Empty : _activityId.ToString(); }
        }

        public void Trace(string message)
        {
            LogEntry(LogLevel.Trace, message);
        }

        public void Debug(string message)
        {
            LogEntry(LogLevel.Debug, message);
        }

        public void Warn(string message)
        {
            LogEntry(LogLevel.Warn, message);
        }

        public void Info(string message)
        {
            LogEntry(LogLevel.Info, message);
        }

        public void Error(string message)
        {
            LogEntry(LogLevel.Error, message);
        }


        private void LogEntry(LogLevel level, string message)
        {
            var eve = new LogEventInfo(level, "", message);
            eve.Properties["ActivityId"] = _activityId;
            _log.Log(eve);
        }
    }
}
