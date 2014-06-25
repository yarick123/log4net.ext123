using System;
using System.Xml;
using log4net.Config;
using log4net.Repository;
using log4net.Tests.Appender;
using NUnit.Framework;

namespace log4net.ext123
{
	[TestFixture]
	public class PatternLayoutExt123_test
	{
		private const string TEST_LOG4NET_CONF = @"
			<log4net>
				<appender name='StringAppender' type='log4net.Tests.Appender.StringAppender'>
					<layout type='log4net.ext123.PatternLayoutExt123'>
						<conversionPattern value='%short-level: %message;' />
					</layout>
				</appender>
				<root>
					<level value='ALL' />
					<appender-ref ref='StringAppender' />
				</root>
			</log4net>";

		private string getLogRepo2Test(string log4net_config=TEST_LOG4NET_CONF) {
			var log4netConfig = new XmlDocument();
			log4netConfig.LoadXml(log4net_config);

			ILoggerRepository rep = LogManager.CreateRepository(Guid.NewGuid().ToString());
			XmlConfigurator.Configure(rep, log4netConfig["log4net"]);

			return rep.Name;
		}

		[Test]
		public void Test_PatternLayoutExt123() {
			string repoName = getLogRepo2Test();
			ILog123 log = Log123Manager.GetLogger(repoName, "a");

			log.Trace("trace");
			log.Debug("Message");
			log.Info(55);
			log.Warn(1);
			log.Error(2);
			log.Fatal(3);

			var appender = (StringAppender)LogManager.GetRepository(repoName).GetAppenders()[0];
			Assert.AreEqual("T: trace;D: Message;I: 55;W: 1;E: 2;F: 3;", appender.GetString());
		}

		[Test]
		public void Test_PatternLayoutExt123_Length() {
			string configTemplate= @"
			<log4net>
				<appender name='a' type='log4net.Tests.Appender.StringAppender'>
					<layout type='log4net.ext123.PatternLayoutExt123'><conversionPattern value='%short-level: %message;'/></layout>
				</appender>
				<appender name='a0' type='log4net.Tests.Appender.StringAppender'>
					<layout type='log4net.ext123.PatternLayoutExt123'><conversionPattern value='%short-level{0}: %message;'/></layout>
				</appender>
				<appender name='a1' type='log4net.Tests.Appender.StringAppender'>
					<layout type='log4net.ext123.PatternLayoutExt123'><conversionPattern value='%short-level{1}: %message;'/></layout>
				</appender>
				<appender name='a2' type='log4net.Tests.Appender.StringAppender'>
					<layout type='log4net.ext123.PatternLayoutExt123'><conversionPattern value='%short-level{2}: %message;'/></layout>
				</appender>
				<appender name='a6' type='log4net.Tests.Appender.StringAppender'>
					<layout type='log4net.ext123.PatternLayoutExt123'><conversionPattern value='%short-level{6}: %message;'/></layout>
				</appender>
				<root>
					<level value='ALL' />
					<appender-ref ref='a' />
					<appender-ref ref='a0' />
					<appender-ref ref='a1' />
					<appender-ref ref='a2' />
					<appender-ref ref='a6' />
				</root>
			</log4net>";

			
			string repoName = getLogRepo2Test(configTemplate);
			ILog123 log = Log123Manager.GetLogger(repoName, "root");

			log.Trace("trace");
			log.Debug("Message");
			log.Info(55);
			log.Warn(1);
			log.Error(2);
			log.Fatal(3);

			var a = (StringAppender) LogManager.GetRepository(repoName).GetAppenders()[0];
			var a0 = (StringAppender) LogManager.GetRepository(repoName).GetAppenders()[1];
			var a1 = (StringAppender) LogManager.GetRepository(repoName).GetAppenders()[2];
			var a2 = (StringAppender) LogManager.GetRepository(repoName).GetAppenders()[3];
			var a6 = (StringAppender) LogManager.GetRepository(repoName).GetAppenders()[4];

			Assert.AreEqual("T: trace;D: Message;I: 55;W: 1;E: 2;F: 3;", a.GetString());
			Assert.AreEqual(": trace;: Message;: 55;: 1;: 2;: 3;", a0.GetString());
			Assert.AreEqual("T: trace;D: Message;I: 55;W: 1;E: 2;F: 3;", a1.GetString());
			Assert.AreEqual("TR: trace;DE: Message;IN: 55;WA: 1;ER: 2;FA: 3;", a2.GetString());
			Assert.AreEqual("TRACE : trace;DEBUG : Message;INFO  : 55;WARN  : 1;ERROR : 2;FATAL : 3;", a6.GetString());
		}
	}
}
