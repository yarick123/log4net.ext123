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

		private string getLogRepo2Test() {
			var log4netConfig = new XmlDocument();
			log4netConfig.LoadXml(TEST_LOG4NET_CONF);

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
	}
}
