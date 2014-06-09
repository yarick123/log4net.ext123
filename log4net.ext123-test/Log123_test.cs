using NUnit.Framework;

namespace log4net.ext123
{
	[TestFixture]
	public class Log123_test
	{
		[Test]
		public void ATest_Log123() {
			var log = Log123Manager.ClassLogger();
			Assert.AreEqual("log4net.ext123.Log123_test", log.Logger.Name);
			Assert.AreEqual("log4net.ext123.Log123_test_static", Log123_test_static.LOG.Logger.Name);
			Assert.AreSame(Log123_test_static.LOG, Log123Manager.GetLogger(typeof(Log123_test_static)));
		}
	}

	public class Log123_test_static
	{
		public static ILog123 LOG = Log123Manager.ClassLogger();
	}
}