using EFCoreHelper;
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

        Container.RegisterSingleton<IGenericRepository<Data.Category>, EFGenericRepository<Data.Category, LogContext>>();
        Container.RegisterSingleton<IGenericRepository<Data.Place>, EFGenericRepository<Data.Place, LogContext>>();
        Container.RegisterSingleton<IGenericRepository<Data.Task>, EFGenericRepository<Data.Task, LogContext>>();
        Container.RegisterSingleton<ILogRepo, LogRepo>();

        Container.RegisterSingleton<ILogUnitOfWork, LogUnitOfWork>();
    }
}