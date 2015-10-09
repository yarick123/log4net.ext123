using System.Collections.Generic;
using log4net.Core;
using log4net.Layout;

namespace log4net.ext123
{
	// https://gist.github.com/AlexanderByndyu/5538568
	// http://www.codeproject.com/Articles/43165/Extending-log-net-s-SmtpAppender-to-customize-subj
	//
	public class SmtpAppenderWithSubjectLayout : log4net.Appender.SmtpAppender
	{
		public PatternLayout SubjectLayout { get; set; }

		protected override void SendBuffer(LoggingEvent[] events) {
			prepareSubject(events);
			base.SendBuffer(events);
		}

		protected virtual void prepareSubject(ICollection<LoggingEvent> events) {
			Subject = null;
			LoggingEvent last_evt = null;
			foreach (LoggingEvent evt in events) {
				last_evt = evt;
				if (Evaluator.IsTriggeringEvent(evt)) {
					Subject = SubjectLayout.Format(evt);
					break;
				}
			}
			if (null == Subject)
				Subject = null != last_evt ? SubjectLayout.Format(last_evt) : string.Format("{0} logging items...", events.Count);
		}
	}
}