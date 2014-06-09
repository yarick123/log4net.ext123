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
		void Trace(object message);
		void Trace(string format, params object[] args);
		void Trace(Exception e, string format=null, params object[] args);
	}

	public class Log123Impl : LoggerWrapperImpl, ILog123, ILoggerWrapper
	{
		private static readonly Type ThisDeclaringType = typeof (Log123Impl);
		private Level myLevelTrace;

		public virtual bool IsTraceEnabled { get { return Logger.IsEnabledFor(myLevelTrace); } }

		public virtual void Trace(object message) {
			if (!IsTraceEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelTrace, message, null);
		}

		public virtual void Trace(string format, params object[] args) {
			if (!IsTraceEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelTrace, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
		}

		public virtual void Trace(Exception e, string format = null, params object[] args) {
			if (!IsTraceEnabled) return;
			Logger.Log(ThisDeclaringType, myLevelTrace, null == format ? null : new SystemStringFormat(CultureInfo.InvariantCulture, format, args), e);
		}

		public Log123Impl(ILogger logger) : base(logger)
		{
			logger.Repository.ConfigurationChanged += LoggerRepositoryConfigurationChanged;
			ReloadLevels(logger.Repository);
		}

		protected virtual void ReloadLevels(ILoggerRepository repository)
		{
			myLevelTrace = repository.LevelMap.LookupWithDefault(Level.Trace);
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
