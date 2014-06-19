using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
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


	public class Log123Manager
	{
		private static readonly WrapperMap MyWrapperMap = new WrapperMap(WrapperCreationHandler);
	
		private static ILoggerWrapper WrapperCreationHandler(ILogger logger) {
			return new Log123Impl(logger);
		}

		private Log123Manager() {}

		public static ILog123 ClassLogger() {
			var stackFrame = new StackTrace().GetFrame(1);
			return GetLogger(stackFrame.GetMethod().DeclaringType);
		}

		/// <summary>
		/// Returns the named logger if it exists
		/// </summary>
		/// <remarks>
		/// <para>If the named logger exists (in the default hierarchy) then it
		/// returns a reference to the logger, otherwise it returns
		/// <c>null</c>.</para>
		/// </remarks>
		/// <param name="name">The fully qualified logger name to look for</param>
		/// <returns>The logger found, or null</returns>
		public static ILog123 Exists(string name) 
		{
			return Exists(Assembly.GetCallingAssembly(), name);
		}

		/// <summary>
		/// Returns the named logger if it exists
		/// </summary>
		/// <remarks>
		/// <para>If the named logger exists (in the specified domain) then it
		/// returns a reference to the logger, otherwise it returns
		/// <c>null</c>.</para>
		/// </remarks>
		/// <param name="domain">the domain to lookup in</param>
		/// <param name="name">The fully qualified logger name to look for</param>
		/// <returns>The logger found, or null</returns>
		public static ILog123 Exists(string domain, string name) 
		{
			return WrapLogger(LoggerManager.Exists(domain, name));
		}

		/// <summary>
		/// Returns the named logger if it exists
		/// </summary>
		/// <remarks>
		/// <para>If the named logger exists (in the specified assembly's domain) then it
		/// returns a reference to the logger, otherwise it returns
		/// <c>null</c>.</para>
		/// </remarks>
		/// <param name="assembly">the assembly to use to lookup the domain</param>
		/// <param name="name">The fully qualified logger name to look for</param>
		/// <returns>The logger found, or null</returns>
		public static ILog123 Exists(Assembly assembly, string name) 
		{
			return WrapLogger(LoggerManager.Exists(assembly, name));
		}

		/// <summary>
		/// Returns all the currently defined loggers in the default domain.
		/// </summary>
		/// <remarks>
		/// <para>The root logger is <b>not</b> included in the returned array.</para>
		/// </remarks>
		/// <returns>All the defined loggers</returns>
		public static ILog123[] GetCurrentLoggers()
		{
			return GetCurrentLoggers(Assembly.GetCallingAssembly());
		}

		/// <summary>
		/// Returns all the currently defined loggers in the specified domain.
		/// </summary>
		/// <param name="domain">the domain to lookup in</param>
		/// <remarks>
		/// The root logger is <b>not</b> included in the returned array.
		/// </remarks>
		/// <returns>All the defined loggers</returns>
		public static ILog123[] GetCurrentLoggers(string domain)
		{
			return WrapLoggers(LoggerManager.GetCurrentLoggers(domain));
		}

		/// <summary>
		/// Returns all the currently defined loggers in the specified assembly's domain.
		/// </summary>
		/// <param name="assembly">the assembly to use to lookup the domain</param>
		/// <remarks>
		/// The root logger is <b>not</b> included in the returned array.
		/// </remarks>
		/// <returns>All the defined loggers</returns>
		public static ILog123[] GetCurrentLoggers(Assembly assembly)
		{
			return WrapLoggers(LoggerManager.GetCurrentLoggers(assembly));
		}

		/// <summary>
		/// Retrieve or create a named logger.
		/// </summary>
		/// <remarks>
		/// <para>Retrieve a logger named as the <paramref name="name"/>
		/// parameter. If the named logger already exists, then the
		/// existing instance will be returned. Otherwise, a new instance is
		/// created.</para>
		/// 
		/// <para>By default, loggers do not have a set level but inherit
		/// it from the hierarchy. This is one of the central features of
		/// log4net.</para>
		/// </remarks>
		/// <param name="name">The name of the logger to retrieve.</param>
		/// <returns>the logger with the name specified</returns>
		public static ILog123 GetLogger(string name)
		{
			return GetLogger(Assembly.GetCallingAssembly(), name);
		}

		/// <summary>
		/// Retrieve or create a named logger.
		/// </summary>
		/// <remarks>
		/// <para>Retrieve a logger named as the <paramref name="name"/>
		/// parameter. If the named logger already exists, then the
		/// existing instance will be returned. Otherwise, a new instance is
		/// created.</para>
		/// 
		/// <para>By default, loggers do not have a set level but inherit
		/// it from the hierarchy. This is one of the central features of
		/// log4net.</para>
		/// </remarks>
		/// <param name="domain">the domain to lookup in</param>
		/// <param name="name">The name of the logger to retrieve.</param>
		/// <returns>the logger with the name specified</returns>
		public static ILog123 GetLogger(string domain, string name)
		{
			return WrapLogger(LoggerManager.GetLogger(domain, name));
		}

		/// <summary>
		/// Retrieve or create a named logger.
		/// </summary>
		/// <remarks>
		/// <para>Retrieve a logger named as the <paramref name="name"/>
		/// parameter. If the named logger already exists, then the
		/// existing instance will be returned. Otherwise, a new instance is
		/// created.</para>
		/// 
		/// <para>By default, loggers do not have a set level but inherit
		/// it from the hierarchy. This is one of the central features of
		/// log4net.</para>
		/// </remarks>
		/// <param name="assembly">the assembly to use to lookup the domain</param>
		/// <param name="name">The name of the logger to retrieve.</param>
		/// <returns>the logger with the name specified</returns>
		public static ILog123 GetLogger(Assembly assembly, string name)
		{
			return WrapLogger(LoggerManager.GetLogger(assembly, name));
		}

		/// <summary>
		/// Shorthand for <see cref="M:LogManager.GetLogger(string)"/>.
		/// </summary>
		/// <remarks>
		/// Get the logger for the fully qualified name of the type specified.
		/// </remarks>
		/// <param name="type">The full name of <paramref name="type"/> will 
		/// be used as the name of the logger to retrieve.</param>
		/// <returns>the logger with the name specified</returns>
		public static ILog123 GetLogger(Type type) 
		{
			return GetLogger(Assembly.GetCallingAssembly(), type.FullName);
		}

		/// <summary>
		/// Shorthand for <see cref="M:LogManager.GetLogger(string)"/>.
		/// </summary>
		/// <remarks>
		/// Get the logger for the fully qualified name of the type specified.
		/// </remarks>
		/// <param name="domain">the domain to lookup in</param>
		/// <param name="type">The full name of <paramref name="type"/> will 
		/// be used as the name of the logger to retrieve.</param>
		/// <returns>the logger with the name specified</returns>
		public static ILog123 GetLogger(string domain, Type type) 
		{
			return WrapLogger(LoggerManager.GetLogger(domain, type));
		}

		/// <summary>
		/// Shorthand for <see cref="M:LogManager.GetLogger(string)"/>.
		/// </summary>
		/// <remarks>
		/// Get the logger for the fully qualified name of the type specified.
		/// </remarks>
		/// <param name="assembly">the assembly to use to lookup the domain</param>
		/// <param name="type">The full name of <paramref name="type"/> will 
		/// be used as the name of the logger to retrieve.</param>
		/// <returns>the logger with the name specified</returns>
		public static ILog123 GetLogger(Assembly assembly, Type type) 
		{
			return WrapLogger(LoggerManager.GetLogger(assembly, type));
		}

		/// <summary>
		/// Lookup the wrapper object for the logger specified
		/// </summary>
		/// <param name="logger">the logger to get the wrapper for</param>
		/// <returns>the wrapper for the logger specified</returns>
		private static ILog123 WrapLogger(ILogger logger)
		{
			return (ILog123) MyWrapperMap.GetWrapper(logger);
		}

		/// <summary>
		/// Lookup the wrapper objects for the loggers specified
		/// </summary>
		/// <param name="loggers">the loggers to get the wrappers for</param>
		/// <returns>Lookup the wrapper objects for the loggers specified</returns>
		private static ILog123[] WrapLoggers(ILogger[] loggers)
		{
			var results = new ILog123[loggers.Length];
			for(int i=0; i<loggers.Length; i++)
			{
				results[i] = WrapLogger(loggers[i]);
			}
			return results;
		}
	}
}
