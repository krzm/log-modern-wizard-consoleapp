using CLI.Core;
using CLI.Core.Lib;
using Core.Lib;
using Log.Data;
using Log.Modern.Lib;
using Unity;
using Unity.Injection;

namespace Log.Modern.Wizard.ConsoleApp;

public class AppCommands : UnityDependencyProvider
{
    public AppCommands(
        IUnityContainer container) 
        : base(container)
    {
    }

    public override void RegisterDependencies()
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