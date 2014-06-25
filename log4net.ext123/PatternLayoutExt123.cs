using System;
using System.IO;
using log4net.Core;
using log4net.Layout;
using log4net.Layout.Pattern;
using log4net.Util;

namespace log4net.ext123
{
	public class ShortLevelPatternConverter : PatternLayoutConverter
	{
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent) {
			if (null == writer) throw new ArgumentNullException("writer");
			if (null == loggingEvent) throw new ArgumentNullException("loggingEvent");

			writer.Write(loggingEvent.Level.DisplayName[0]);
		}
	}

	public class PatternLayoutExt123 : PatternLayout
	{
		public PatternLayoutExt123() {
			AddConverter(new ConverterInfo{Name = "short-level", Type = typeof(ShortLevelPatternConverter)});
		}
	}
}
