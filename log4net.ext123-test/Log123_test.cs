using System;
using System.Xml;
using log4net.Config;
using log4net.Repository;
using log4net.Tests.Appender;
using NUnit.Framework;

namespace log4net.ext123
{
	[TestFixture]
	public class Log123_test
	{
		[Test]
		public void Test_Log123() {
			var log = Log123Manager.ClassLogger();
			Assert.AreEqual("log4net.ext123.Log123_test", log.Logger.Name);
			Assert.AreEqual("log4net.ext123.Log123_test_static", Log123_test_static.LOG.Logger.Name);
			Assert.AreSame(Log123_test_static.LOG, Log123Manager.GetLogger(typeof(Log123_test_static)));
		}

		private const string TEST_LOG4NET_CONF = @"
			<log4net>
				<appender name='StringAppender' type='log4net.Tests.Appender.StringAppender'>
					<layout type='log4net.Layout.PatternLayout'>
						<conversionPattern value='%level - %message;' />
					</layout>
				</appender>
				<root>
					<level value='ALL' />
					<appender-ref ref='StringAppender' />
				</root>
				<logger name='W'>
					<level value='WARN' />
				</logger>
			</log4net>";

		private string getLogRepo2Test() {
			var log4netConfig = new XmlDocument();
			log4netConfig.LoadXml(TEST_LOG4NET_CONF);

			ILoggerRepository rep = LogManager.CreateRepository(Guid.NewGuid().ToString());
			XmlConfigurator.Configure(rep, log4netConfig["log4net"]);

			return rep.Name;
		}

		[Test]
		public void Test_LogEnabled() {
			string repoName = getLogRepo2Test();
			ILog123 a = Log123Manager.GetLogger(repoName, "a");

			Assert.IsTrue(a.IsTraceEnabled);
			Assert.IsTrue(a.IsDebugEnabled);
			Assert.IsTrue(a.IsInfoEnabled);
			Assert.IsTrue(a.IsWarnEnabled);
			Assert.IsTrue(a.IsErrorEnabled);
			Assert.IsTrue(a.IsFatalEnabled);

			ILog123 w = Log123Manager.GetLogger(repoName, "W");
			Assert.IsFalse(w.IsTraceEnabled);
			Assert.IsFalse(w.IsDebugEnabled);
			Assert.IsFalse(w.IsInfoEnabled);
			Assert.IsTrue(w.IsWarnEnabled);
			Assert.IsTrue(w.IsErrorEnabled);
			Assert.IsTrue(w.IsFatalEnabled);
		}

		[Test]
		public void Test_LogMessage() {
			string repoName = getLogRepo2Test();
			ILog123 log = Log123Manager.GetLogger(repoName, "a");

			log.Trace("trace");
			log.Debug("Message");
			log.Info(55);

			var appender = (StringAppender)LogManager.GetRepository(repoName).GetAppenders()[0];
			Assert.AreEqual("TRACE - trace;DEBUG - Message;INFO - 55;", appender.GetString());
			appender.Reset();

			log.Warn("warn");
			log.Error("Message");
			log.Fatal(50);

			Assert.AreEqual("WARN - warn;ERROR - Message;FATAL - 50;", appender.GetString());
		}

		[Test]
		public void Test_LogFormat() {
			string repoName = getLogRepo2Test();
			ILog123 log = Log123Manager.GetLogger(repoName, "a");

			log.Trace("t {0}");
			log.Trace("t {0}", 1);
			log.Debug("d {0}", 2);
			log.Info("i {0}", 3);

			var appender = (StringAppender)LogManager.GetRepository(repoName).GetAppenders()[0];
			Assert.AreEqual("TRACE - t {0};TRACE - t 1;DEBUG - d 2;INFO - i 3;", appender.GetString());
			appender.Reset();

			log.Warn("w {0}", 4);
			log.Error("e {0}", 5);
			log.Fatal("f {0}", 6);

			Assert.AreEqual("WARN - w 4;ERROR - e 5;FATAL - f 6;", appender.GetString());
		}
	}


	public class Log123_test_static
	{
		public static ILog123 LOG = Log123Manager.ClassLogger();
	}
}