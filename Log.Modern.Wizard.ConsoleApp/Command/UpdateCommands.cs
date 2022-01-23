using CLI.Core.Lib;
using CommandDotNet;
using Log.Data;

namespace Log.Modern.Wizard.ConsoleApp;

[Command("update")]
public class UpdateCommands
{
    private readonly IUpdateWizard<Data.Place> placeWizard;
    private readonly IUpdateWizard<Data.Category> categoryWizard;
    private readonly IUpdateWizard<Data.Task> taskWizard;
    private readonly IUpdateWizard<LogModel> logWizard;

    public UpdateCommands(
        IUpdateWizard<Data.Place> placeWizard
        , IUpdateWizard<Data.Category> categoryWizard
        , IUpdateWizard<Data.Task> taskWizard
        , IUpdateWizard<Data.LogModel> logWizard)
    {
        this.placeWizard = placeWizard;
        this.categoryWizard = categoryWizard;
        this.taskWizard = taskWizard;
        this.logWizard = logWizard;
    }

    [Command("place")]
    public void InsertPlace()
    {
        placeWizard.Update();
    }

    [Command("category")]
    public void InsertCategory()
    {
        categoryWizard.Update();
    }

    [Command("task")]
    public void InsertTask()
    {
        taskWizard.Update();
    }

    [Command("log")]
    public void InsertLog()
    {
        logWizard.Update();
    }
}