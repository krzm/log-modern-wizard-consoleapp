using Core;
using Core.Lib;
using Log.Data;
using Unity;

namespace Log.Modern.Wizard.ConsoleApp;

public class AppDatabase : UnityDependencyProvider
{
    public AppDatabase(
        IUnityContainer container) 
            : base(container)
    {
    }

    public override void RegisterDependencies()
    {
        Container.RegisterSingleton<LogContext>();

        Container.RegisterSingleton<IGenericRepository<Data.Category>, EFGenericRepository<Data.Category, LogContext>>();
        Container.RegisterSingleton<IGenericRepository<Data.Place>, EFGenericRepository<Data.Place, LogContext>>();
        Container.RegisterSingleton<IGenericRepository<Data.Task>, EFGenericRepository<Data.Task, LogContext>>();
        Container.RegisterSingleton<ILogRepo, LogRepo>();

        Container.RegisterSingleton<ILogUnitOfWork, LogUnitOfWork>();
    }
}