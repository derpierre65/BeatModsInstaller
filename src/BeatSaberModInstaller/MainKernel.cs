using BeatSaberModInstaller.Core;
using BeatSaberModInstaller.Handler;
using Microsoft.Extensions.Logging;
using Ninject;
using Ninject.Modules;

namespace BeatSaberModInstaller
{
    public class MainKernel : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoggerFactory>().ToMethod(x => { return new LoggerFactory().AddLog4Net(); });
            Bind<ILogger>().ToMethod(x =>
            {
                var loggerFactory = x.Kernel.Get<ILoggerFactory>();
                var loggerType = x.Request.Target?.Member.DeclaringType;
                return loggerFactory.CreateLogger(loggerType);
            });
            Bind<FileHelper>().ToSelf().InSingletonScope();
            Bind<HttpHelper>().ToSelf().InSingletonScope();
            Bind<BeatModsHandler>().ToSelf().InSingletonScope();
            Bind<BeatSaverHandler>().ToSelf().InSingletonScope();
            Bind<SettingsHandler>().ToSelf().InSingletonScope();
        }
    }
}
