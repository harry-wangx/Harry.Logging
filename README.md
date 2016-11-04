Harry.Logging
=======

**Package**: `Harry.Logging`  
NuGet (`master`): [![](http://img.shields.io/nuget/v/Harry.Logging.svg?style=flat-square)](http://www.nuget.org/packages/Harry.Logging)  
**Package**: `Harry.Logging.Nlog`  
NuGet (`master`): [![](http://img.shields.io/nuget/v/Harry.Logging.Nlog.svg?style=flat-square)](http://www.nuget.org/packages/Harry.Logging.Nlog)

* Harry.Logging是一个日志组件,参考了微软的[Logging](https://github.com/aspnet/Logging "Logging").
* 支持.net 2/3.5/4.0/4.5/net core
* 类库中调用`Harry.Logging`写入日志记录后,并不真正记录日志,而是将内容传递给provider.这样在类库中就可以只管按需求写日志,而不必关心日志信息最终会输出到哪里.
* 在最终的应用程序中,需要添加provider到`Harry.Logging`.

### Providers
* [***Harry.Logging.NLog***](https://github.com/harry-wangx/Harry.Logging/tree/master/src/Harry.Logging.NLog) -负责将日志信息写到Nlog组件.
* [***Harry.Logging.Log4Net***](https://github.com/harry-wangx/Harry.Logging/tree/master/src/Harry.Logging.Log4Net) -负责将日志信息写到Log4Net组件.**目前log4net无net core版本**

### 示例代码
```c#
            //以下代码只在最终应用程序中使用一次
            LoggerFactory.Instance.AddNLog();    

			//以下代码放在需要记录日志的地方
            ILogger logger = LoggerFactory.Instance.CreateLogger("Program");
            logger.Debug("debug info");
```


----------

**欢迎加Q群:7957181**