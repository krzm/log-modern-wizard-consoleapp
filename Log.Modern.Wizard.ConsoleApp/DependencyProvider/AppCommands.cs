using CLIHelper;
using CLIReader;
using CLIWizardHelper;
using Log.Data;
using Log.Wizard.Lib;
using Unity;
using Unity.Injection;

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
        Container.RegisterSingleton<IInsertWizard<Data.Place>, PlaceInsertWizard>(
            new InjectionConstructor(
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<IOutput>()
            ));

        Container.RegisterSingleton<IInsertWizard<Data.Category>, CategoryInsertWizard>(
            new InjectionConstructor(
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<IOutput>()
            ));

        Container.RegisterSingleton<IInsertWizard<Data.Task>, TaskInsertWizard>(
            new InjectionConstructor(
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<IOutput>()
            ));

        Container.RegisterSingleton<IInsertWizard<Data.LogModel>, LogInsertWizard>(
            new InjectionConstructor(
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<IReader<string>>(nameof(OptionalTextReader))
                , Container.Resolve<IOutput>()
                , Container.Resolve<IReader<DateTime>>(nameof(RequiredDateTimeReader))
                , Container.Resolve<IReader<DateTime?>>(nameof(OptionalDateTimeReader))
            ));
    }

    private void RegisterUpdateCommands()
    {
        Container.RegisterSingleton<IUpdateWizard<Data.Place>, PlaceUpdateWizard>(
            new InjectionConstructor(
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<IOutput>()
            ));

        Container.RegisterSingleton<IUpdateWizard<Data.Category>, CategoryUpdateWizard>(
            new InjectionConstructor(
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<IOutput>()
            ));

         Container.RegisterSingleton<IUpdateWizard<Data.Task>, TaskUpdateWizard>(
            new InjectionConstructor(
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<IOutput>()
            ));

         Container.RegisterSingleton<IUpdateWizard<Data.LogModel>, LogUpdateWizard>(
            new InjectionConstructor(
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<IOutput>()
                , Container.Resolve<IReader<string>>(nameof(OptionalTextReader))
                , Container.Resolve<IReader<DateTime>>(nameof(RequiredDateTimeReader))
                , Container.Resolve<IReader<DateTime?>>(nameof(OptionalDateTimeReader))
            ));
    }
}