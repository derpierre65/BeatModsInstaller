using BeatSaberModInstaller.Core;
using BeatSaberModInstaller.Handler;
using Ninject.Modules;

namespace BeatSaberModInstaller
{
    public class MainKernel : NinjectModule
    {
        public override void Load()
        {
            Bind<FileHelper>().ToSelf().InSingletonScope();
            Bind<HttpHelper>().ToSelf().InSingletonScope();
            Bind<BeatModsHandler>().ToSelf().InSingletonScope();
            Bind<BeatSaverHandler>().ToSelf().InSingletonScope();
            Bind<SettingsHandler>().ToSelf().InSingletonScope();
        }
    }
}
