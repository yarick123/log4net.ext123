using System.Collections.Generic;
using System.Linq;
using log4net.Appender;
using log4net.Core;

namespace log4net.ext123
{
	public class EventCounter
	{
		public long Count { get { return myCount; } }

		public void inc() {
			++myCount;
		}

		private long myCount;
	}

	/// <summary>
	/// collects number of logging events for every log level
	/// </summary>
	/// <example>
	/// log4net.xml:
	/// &lt;log4net&gt;
	/// 	&lt;appender name="Statistics" type="log4net.ext123.StatisticAppender" /&gt;
	/// 	&lt;root&gt;
	/// 		&lt;level value="ALL" /&gt;
	/// 		&lt;appender-ref ref="Statistics" /&gt;
	/// 	&lt;/root&gt;
	/// &lt;/log4net&gt;
	/// </example>
	/// <example>
	/// usage:
	/// 	StatisticAppender stat = StatisticAppender.getStatisticAppender();
	/// 	if (stat.getLevelCount(log4net.Core.Level.Fatal) &lt; 0 &amp;&amp;
	/// 		stat.getLevelCount(log4net.Core.Level.Error) &gt; 0 ||
	/// 		stat.getLevelCount(log4net.Core.Level.Warn) &gt; 0)
	/// 	{
	/// 		LOG.Fatal("errors: {0}, warnings: {1}", stat.getLevelCount(log4net.Core.Level.Error), stat.getLevelCount(log4net.Core.Level.Warn));
	/// 	}
	/// </example>
	public class StatisticAppender : AppenderSkeleton
	{
		private Dictionary<int, EventCounter> myStatistic = new Dictionary<int, EventCounter>();

		protected override void Append(LoggingEvent loggingEvent) {
			int level = loggingEvent.Level.Value;
			lock (myStatistic) {
				EventCounter counter;
				if (!myStatistic.TryGetValue(level, out counter)) {
					counter = new EventCounter();
					myStatistic[level] = counter;
				}
				counter.inc();
			}
		}

		public Dictionary<int, EventCounter>.KeyCollection getStatisticLevels() {
			lock (myStatistic) {
				return myStatistic.Keys;
			}
		}

		public long getLevelCount(int level) {
			lock (myStatistic) {
				EventCounter counter;
				return myStatistic.TryGetValue(level, out counter) ? counter.Count : 0L;
			}
		}

		public long getLevelCount(Level level) {
			return getLevelCount(level.Value);
		}

		public void clearStatistic() {
			lock (myStatistic) {
				myStatistic.Clear();
			}
		}

		public void clearLevelStatistic(int level) {
			lock (myStatistic) {
				myStatistic.Remove(level);
			}
		}

		/// <summary>
		/// returns specific StatisticAppender. If the name is not specified, returns the first one.
		/// </summary>
		/// <param name="name">appender name, null to get the first one</param>
		/// <returns>null if the appender does not exist</returns>
		public static StatisticAppender getStatisticAppender(string name = null) {
			var appenders = log4net.LogManager.GetRepository().GetAppenders();
			return appenders.OfType<StatisticAppender>().Where(a => name == a.Name || null == name).First();
		}
	}
}