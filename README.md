log4net.ext123
==============

log4net extensions v.1.1

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

yarick123@github.com
