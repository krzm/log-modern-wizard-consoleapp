using DIHelper;
using DIHelper.Unity;
using Unity;

namespace Log.Modern.Wizard.ConsoleApp;

public class Program
{
    static void Main(string[] args)
	{
		IBootstraper booter = new Bootstraper(
			new UnityDependencySuite(
				new UnityContainer().AddExtension(new Diagnostic())));
		booter.Boot(args);
	}
}