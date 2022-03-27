using CLIHelper;
using CLIReader;
using CLIWizardHelper;
using Log.Data;
using Log.Wizard.Lib;
using Serilog;
using Unity;
using Unity.Injection;
using Task = Log.Data.Task;

namespace Log.Modern.Wizard.ConsoleApp;

public class AppCommands 
    : DIHelper.Unity.UnityDependencySet
{
    public AppCommands(
        IUnityContainer container) 
        : base(container)
    {
    }

    public override void Register()
    {
        RegisterInsertCommands();
        RegisterUpdateCommands();
    }

    private void RegisterInsertCommands()
    {
        Container.RegisterSingleton<IInsertWizard<Place>, PlaceInsertWizard>(
            new InjectionConstructor(
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<ILogger>()
            ));

        Container.RegisterSingleton<IInsertWizard<Category>, CategoryInsertWizard>(
            new InjectionConstructor(
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<ILogger>()
            ));

        Container.RegisterSingleton<IInsertWizard<Task>, TaskInsertWizard>(
            new InjectionConstructor(
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<ILogger>()
            ));

        Container.RegisterSingleton<IInsertWizard<LogModel>, LogInsertWizard>(
            new InjectionConstructor(
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<IReader<string>>(nameof(OptionalTextReader))
                , Container.Resolve<ILogger>()
                , Container.Resolve<IReader<DateTime>>(nameof(RequiredDateTimeReader))
                , Container.Resolve<IReader<DateTime?>>(nameof(OptionalDateTimeReader))
            ));
    }

    private void RegisterUpdateCommands()
    {
        Container.RegisterSingleton<IUpdateWizard<Place>, PlaceUpdateWizard>(
            new InjectionConstructor(
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<ILogger>()
            ));

        Container.RegisterSingleton<IUpdateWizard<Category>, CategoryUpdateWizard>(
            new InjectionConstructor(
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<ILogger>()
            ));

         Container.RegisterSingleton<IUpdateWizard<Task>, TaskUpdateWizard>(
            new InjectionConstructor(
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<ILogger>()
            ));

         Container.RegisterSingleton<IUpdateWizard<LogModel>, LogUpdateWizard>(
            new InjectionConstructor(
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<ILogger>()
                , Container.Resolve<IReader<string>>(nameof(OptionalTextReader))
                , Container.Resolve<IReader<DateTime>>(nameof(RequiredDateTimeReader))
                , Container.Resolve<IReader<DateTime?>>(nameof(OptionalDateTimeReader))
            ));
    }
}