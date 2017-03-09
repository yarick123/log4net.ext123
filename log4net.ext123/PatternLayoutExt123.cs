using log4net.Core;
using log4net.Layout;
using log4net.Layout.Pattern;
using log4net.Util;
using System;
using System.IO;

namespace log4net.ext123
{
	// sample 1: <layout type='log4net.ext123.PatternLayoutExt123'><conversionPattern value='%short-level - %message' /></layout>
	// sample 2: <layout type='log4net.ext123.PatternLayoutExt123'><conversionPattern value='%short-level{2} - %message' /></layout>
	//
	public class ShortLevelPatternConverter : PatternLayoutConverter, IOptionHandler
	{
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent) {
			if (null == writer) throw new ArgumentNullException("writer");
			if (null == loggingEvent) throw new ArgumentNullException("loggingEvent");

			string levelDisplayName = loggingEvent.Level.DisplayName;

			if (1 == myLevelNameLength)
				writer.Write(levelDisplayName[0]);
			else if (myLevelNameLength > 0)
				writer.Write(levelDisplayName.Length < myLevelNameLength
					? levelDisplayName.PadRight(myLevelNameLength)
					: levelDisplayName.Substring(0, myLevelNameLength));
		}

		public void ActivateOptions()
		{
			myLevelNameLength = 1;
			if (null == Option) return;

			string optStr = Option.Trim();
			if (0 != optStr.Length) {
				int lengthVal;
				if (SystemInfo.TryParse(optStr, out lengthVal))
				{
					if (lengthVal < 0)
						LogLog.Error(DeclaringType, "ShortLevelPatternConverter: Length option (" + optStr + ") isn't a positive integer.");
					else
						myLevelNameLength = lengthVal;
				}
				else
					LogLog.Error(DeclaringType, "ShortLevelPatternConverter: Length option '" + optStr + "' not a decimal integer.");
			}
		}

		private readonly static Type DeclaringType = typeof(ShortLevelPatternConverter);
		private int myLevelNameLength = 1;
	}

	public class PatternLayoutExt123 : DynamicPatternLayout
	{
		public PatternLayoutExt123() {
			AddConverter(new ConverterInfo { Name = "short-level", Type = typeof(ShortLevelPatternConverter) });
		}
	}
}
