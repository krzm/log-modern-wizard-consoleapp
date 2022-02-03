using DataToTable;
using Log.Data;
using Log.Modern.Lib;
using Unity;

namespace Log.Modern.Wizard.ConsoleApp;

public class AppOutput 
    : DIHelper.Unity.AppOutput
{
    public AppOutput(
        IUnityContainer container) 
            : base(container)
    {
    }

    protected override void RegisterColumnCalculators()
    {
        Container.RegisterSingleton<IColumnCalculator<LogModel>, ColumnCalculator<LogModel>>();
        Container.RegisterSingleton<IColumnCalculator<Data.Task>, ColumnCalculator<Data.Task>>();
        Container.RegisterSingleton<IColumnCalculator<Data.Category>, ColumnCalculator<Data.Category>>();
        Container.RegisterSingleton<IColumnCalculator<Data.Place>, ColumnCalculator<Data.Place>>();
    }
    
    protected override void RegisterTableProviders()
    {
        Container.RegisterSingleton<IDataToText<LogModel>, LogTableProvider>();
        Container.RegisterSingleton<IDataToText<Data.Task>, TaskTableProvider>();
        Container.RegisterSingleton<IDataToText<Data.Category>, ModelATable<Data.Category>>();
        Container.RegisterSingleton<IDataToText<Data.Place>, ModelATable<Data.Place>>();
    }
}