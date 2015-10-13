log4net.ext123
==============

log4net extensions v.1.3

## Class Log123Manager:
- no more long initialization commands for static class loggers - use method Log123Manager.ClassLogger():
  - *old*:
```java
private static readonly ILog LOG = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
```
  - **new**:
```java
private static readonly ILog123 LOG123 = Log123Manager.ClassLogger();
```

## Interface ILog123:
- do not care any more of different methods for formatted and normal strings:
  - *old*: `LOG.WarnFormat("message {0}", "formatted!");`
  - **new**: **`LOG123.Warn("message {0}", "formatted!");`**
  - the same: `LOG123.Warn("message!");`

- do not care any more of specific methods and parameters for the exception logging:
  - *old*: `LOG.Warn(exception.Message, exception);`
  - **new**:**`LOG123.Warn(exception);`**
  - *old*: `LOG.Warn(String.Format("message {0}", "formatted!"), exception);`
  - **new**:**`LOG123.Warn(exception, "message {0}", "formatted!");`**

- added Trace methods:
  - *old*:
```java
if (LOG.Logger.IsEnabledFor(Level.Trace))
    LOG.Logger.Log(GetType(), Level.Trace, String.Format("message {0}", "formatted!"), null);
```
  - **new**: **`LOG123.Trace("message {0}", "formatted!");`**

## Class PatternLayoutExt123
- can log the specified number of the first N charackters from the log level name (pattern **%short-level{N}**), by default N=1:
  - *old*: 'WARN - some warning message'
  - **new**: '**W** - some warning message'
  - **old config pattern**: `<layout type="log4net.Layout.PatternLayout"><conversionPattern value="`**`%level`**` - %message%n"/></layout>`
  - **new config pattern**: `<layout type='log4net.ext123.PatternLayoutExt123'><conversionPattern value='`**`%short-level`**` - %message%n'/></layout>`

## Class [SmtpAppenderWithSubjectLayout](https://gist.github.com/AlexanderByndyu/5538568)
- the email subject field is evaluated with the log event, caused sending the email:
```xml
<appender name="SmtpAppender" type="log4net.ext123.SmtpAppenderWithSubjectLayout,log4net.ext123">
  <subjectLayout>
    <conversionPattern value="%property{log4net:HostName}: problems, %date{yyyy-MM-dd HH:mm:ssK}" />
  </subjectLayout>
	...
</appender>
```

## Class StatisticAppender
- collects number of logging events for every log level. Is useful if an action needed, if there were warnings,
e.g. send email before exit:
```xml
<appender name="Statistics" type="log4net.ext123.StatisticAppender" />
<root>
  <level value="ALL" />
  <appender-ref ref="Statistics" />
  ...
</root>
```
```java
// send an email if there were errors or warnings
//
StatisticAppender stat = StatisticAppender.getStatisticAppender();

if (null != stat && stat.getLevelCount(log4net.Core.Level.Fatal) == 0 &&
     (stat.getLevelCount(log4net.Core.Level.Error) > 0 ||
      stat.getLevelCount(log4net.Core.Level.Warn)  > 0))
{
	ITriggeringEventEvaluator prevSmtpTriggingEvaluator = null;
	if (null != smtpAppender) {
		prevSmtpTriggingEvaluator = smtpAppender.Evaluator;
		smtpAppender.Evaluator = new AlwaysTrueLog4NetTriggeringEventEvaluator();
	}

	LOG.Warn("The generating finished with {0} errors and {1} warnings",
		stat.getLevelCount(log4net.Core.Level.Error),
		stat.getLevelCount(log4net.Core.Level.Warn) + 1 /*this is a warning as well*/);

	if (null != smtpAppender)
		smtpAppender.Evaluator = prevSmtpTriggingEvaluator;
}
```
```java
public class AlwaysTrueLog4NetTriggeringEventEvaluator : ITriggeringEventEvaluator
{
	public bool IsTriggeringEvent(LoggingEvent loggingEvent) {
		return true;
	}
}

private static ILog123 LOG = Log123Manager.ClassLogger();
```

yarick123@github.com
