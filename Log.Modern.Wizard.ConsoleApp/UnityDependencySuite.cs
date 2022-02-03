using DIHelper;
using Unity;

namespace Log.Modern.Wizard.ConsoleApp;

public class UnityDependencySuite 
    : DIHelper.Unity.UnityDependencySuite
{
    public UnityDependencySuite(
        IUnityContainer container) 
        : base(container) 
    {
    }

    protected override void RegisterDatabase()=> 
        RegisterSet<AppDatabase>();

    protected override void RegisterConsoleOutput() => 
        RegisterSet<AppOutput>();

    protected override void RegisterCommands() => 
        RegisterSet<AppCommands>();

    protected override void RegisterProgram() => 
        Container.RegisterSingleton<IAppProgram, AppProgram>();
}