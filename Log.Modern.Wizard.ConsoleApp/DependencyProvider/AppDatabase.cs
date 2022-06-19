using EFCore.Helper;
using Log.Data;
using Unity;

namespace Log.Modern.Wizard.ConsoleApp;

public class AppDatabase 
    : DIHelper.Unity.UnityDependencySet
{
    public AppDatabase(
        IUnityContainer container) 
            : base(container)
    {
    }

    public override void Register()
    {
        Container.RegisterSingleton<LogContext>();

        Container.RegisterSingleton<IRepository<Data.Category>, EFRepository<Data.Category, LogContext>>();
        Container.RegisterSingleton<IRepository<Data.Place>, EFRepository<Data.Place, LogContext>>();
        Container.RegisterSingleton<IRepository<Data.Task>, EFRepository<Data.Task, LogContext>>();
        Container.RegisterSingleton<ILogRepo, LogRepo>();

        Container.RegisterSingleton<ILogUnitOfWork, LogUnitOfWork>();
    }
}