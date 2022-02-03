using CommandDotNet;
using CommandDotNet.Repl;
using Unity;

namespace Log.Modern.Wizard.ConsoleApp;

public class AppProgram 
    : CommandDotNet.Helper.AppProgramUnity<AppProgram>
{
	private static bool inSession;

    [Subcommand]
    public InsertCommands? WizardInsertCommands { get; set; }

    [Subcommand]
    public UpdateCommands? WizardUpdateCommands { get; set; }

    public AppProgram(
        IUnityContainer container) 
            : base(container)
    {
    }

    [DefaultCommand()]
    public void StartSession(
        CommandContext context,
        ReplSession replSession)
    {
        if (inSession == false)
        {
            context.Console.WriteLine("start session");
            inSession = true;
            replSession.Start();
        }
        else
        {
            context.Console.WriteLine($"no session {inSession}");
            context.ShowHelpOnExit = true;
        }
    }

    protected override void RegisterCommandClasses(AppRunner appRunner)
    {
        var commandClassTypes = appRunner.GetCommandClassTypes();
        var registeredExplicitly = new Type[] 
        {
            // typeof()
        };
        foreach (var type in commandClassTypes)
        {
            if(registeredExplicitly.Contains(type.type)) continue;
            Container.RegisterSingleton(type.type);
        }
    }
}