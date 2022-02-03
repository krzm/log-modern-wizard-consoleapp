using CLIWizardHelper;
using CommandDotNet;
using Log.Data;

namespace Log.Modern.Wizard.ConsoleApp;

[Command("insert")]
public class InsertCommands
{
    private readonly IInsertWizard<Data.Place> placeWizard;
    private readonly IInsertWizard<Data.Category> categoryWizard;
    private readonly IInsertWizard<Data.Task> taskWizard;
    private readonly IInsertWizard<LogModel> logWizard;

    public InsertCommands(
        IInsertWizard<Data.Place> placeWizard
        , IInsertWizard<Data.Category> categoryWizard
        , IInsertWizard<Data.Task> taskWizard
        , IInsertWizard<Data.LogModel> logWizard)
    {
        this.placeWizard = placeWizard;
        this.categoryWizard = categoryWizard;
        this.taskWizard = taskWizard;
        this.logWizard = logWizard;
    }

    [Command("place")]
    public void InsertPlace()
    {
        placeWizard.Insert();
    }

    [Command("category")]
    public void InsertCategory()
    {
        categoryWizard.Insert();
    }

    [Command("task")]
    public void InsertTask()
    {
        taskWizard.Insert();
    }

    [Command("log")]
    public void InsertLog()
    {
        logWizard.Insert();
    }
}