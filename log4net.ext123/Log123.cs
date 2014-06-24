using System;
using System.Globalization;
using log4net.Core;
using log4net.Repository;
using log4net.Util;

namespace log4net.ext123
{
	public interface ILog123 : ILoggerWrapper
	{
		bool IsTraceEnabled { get; }
		bool IsDebugEnabled { get; }
		bool IsInfoEnabled { get; }
		bool IsWarnEnabled { get; }
		bool IsErrorEnabled { get; }
		bool IsFatalEnabled { get; }

		void Trace(object message);
		void Debug(object message);
		void Info(object message);
		void Warn(object message);
		void Error(object message);
		void Fatal(object message);

		void Trace(string message);
		void Debug(string message);
		void Info(string message);
		void Warn(string message);
		void Error(string message);
		void Fatal(string message);

		void Trace(string format, params object[] args);
		void Debug(string format, params object[] args);
		void Info(string format, params object[] args);
		void Warn(string format, params object[] args);
		void Error(string format, params object[] args);
		void Fatal(string format, params object[] args);

		void Trace(Exception e, string message=null);
		void Debug(Exception e, string message=null);
		void Info(Exception e, string message=null);
		void Warn(Exception e, string message=null);
		void Error(Exception e, string message=null);
		void Fatal(Exception e, string message=null);

		void Trace(Exception e, string format, params object[] args);
		void Debug(Exception e, string format, params object[] args);
		void Info(Exception e, string format, params object[] args);
		void Warn(Exception e, string format, params object[] args);
		void Error(Exception e, string format, params object[] args);
		void Fatal(Exception e, string format, params object[] args);
	}


	public class Log123Impl : LoggerWrapperImpl, ILog123, ILoggerWrapper
	{
		private static readonly Type ThisDeclaringType = typeof (Log123Impl);
		private Level myLevelTrace;
		private Level myLevelDebug;
		private Level myLevelInfo;
		private Level myLevelWarn;
		private Level myLevelError;
		private Level myLevelFatal;

		public virtual bool IsTraceEnabled { get { return Logger.IsEnabledFor(myLevelTrace); } }
		public virtual bool IsDebugEnabled { get { return Logger.IsEnabledFor(myLevelDebug); } }
		public virtual bool IsInfoEnabled { get { return Logger.IsEnabledFor(myLevelInfo); } }
		public virtual bool IsWarnEnabled { get { return Logger.IsEnabledFor(myLevelWarn); } }
		public virtual bool IsErrorEnabled { get { return Logger.IsEnabledFor(myLevelError); } }
		public virtual bool IsFatalEnabled { get { return Logger.IsEnabledFor(myLevelFatal); } }

		public virtual void Trace(object message) {
			if (!IsTraceEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelTrace, message, null);
		}

		public virtual void Debug(object message) {
			if (!IsDebugEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelDebug, message, null);
		}

		public virtual void Info(object message) {
			if (!IsInfoEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelInfo, message, null);
		}

		public virtual void Warn(object message) {
			if (!IsWarnEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelWarn, message, null);
		}

		public virtual void Error(object message) {
			if (!IsErrorEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelError, message, null);
		}

		public virtual void Fatal(object message) {
			if (!IsFatalEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelFatal, message, null);
		}

		public virtual void Trace(string message) {
			if (!IsTraceEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelTrace, message, null);
		}

		public virtual void Debug(string message) {
			if (!IsDebugEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelDebug, message, null);
		}

		public virtual void Info(string message) {
			if (!IsInfoEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelInfo, message, null);
		}

		public virtual void Warn(string message) {
			if (!IsWarnEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelWarn, message, null);
		}

		public virtual void Error(string message) {
			if (!IsErrorEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelError, message, null);
		}

		public virtual void Fatal(string message) {
			if (!IsFatalEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelFatal, message, null);
		}

		public virtual void Trace(string format, params object[] args) {
			if (!IsTraceEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelTrace, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
		}

		public virtual void Debug(string format, params object[] args) {
			if (!IsDebugEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelDebug, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
		}

		public virtual void Info(string format, params object[] args) {
			if (!IsInfoEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelInfo, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
		}

		public virtual void Warn(string format, params object[] args) {
			if (!IsWarnEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelWarn, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
		}

		public virtual void Error(string format, params object[] args) {
			if (!IsErrorEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelError, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
		}

		public virtual void Fatal(string format, params object[] args) {
			if (!IsFatalEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelFatal, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
		}

		public virtual void Trace(Exception e, string message) {
			if (!IsTraceEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelTrace, message??e.Message, e);
		}

		public virtual void Debug(Exception e, string message) {
			if (!IsDebugEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelDebug, message??e.Message, e);
		}

		public virtual void Info(Exception e, string message) {
			if (!IsInfoEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelInfo, message??e.Message, e);
		}

		public virtual void Warn(Exception e, string message) {
			if (!IsWarnEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelWarn, message??e.Message, e);
		}

		public virtual void Error(Exception e, string message) {
			if (!IsErrorEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelError, message??e.Message, e);
		}

		public virtual void Fatal(Exception e, string message) {
			if (!IsFatalEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelFatal, message??e.Message, e);
		}

		public virtual void Trace(Exception e, string format, params object[] args) {
			if (!IsTraceEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelTrace, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), e);
		}

		public virtual void Debug(Exception e, string format, params object[] args) {
			if (!IsDebugEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelDebug, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), e);
		}

		public virtual void Info(Exception e, string format, params object[] args) {
			if (!IsInfoEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelInfo, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), e);
		}

		public virtual void Warn(Exception e, string format, params object[] args) {
			if (!IsWarnEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelWarn, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), e);
		}

		public virtual void Error(Exception e, string format, params object[] args) {
			if (!IsErrorEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelError, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), e);
		}

		public virtual void Fatal(Exception e, string format, params object[] args) {
			if (!IsFatalEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelFatal, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), e);
		}

		public Log123Impl(ILogger logger) : base(logger)
		{
			logger.Repository.ConfigurationChanged += LoggerRepositoryConfigurationChanged;
			ReloadLevels(logger.Repository);
		}

		protected virtual void ReloadLevels(ILoggerRepository repository)
		{
			var m = repository.LevelMap;
			myLevelTrace = m.LookupWithDefault(Level.Trace);
			myLevelDebug = m.LookupWithDefault(Level.Debug);
			myLevelInfo = m.LookupWithDefault(Level.Info);
			myLevelWarn = m.LookupWithDefault(Level.Warn);
			myLevelError = m.LookupWithDefault(Level.Error);
			myLevelFatal = m.LookupWithDefault(Level.Fatal);
		}

		private void LoggerRepositoryConfigurationChanged(object sender, EventArgs e)
		{
			var repository = sender as ILoggerRepository;
			if (repository == null) return;
			ReloadLevels(repository);
		}
	}
}
