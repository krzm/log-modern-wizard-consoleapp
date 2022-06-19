using DIHelper;
using Log.Modern.Wizard.ConsoleApp;
using Unity;

IBootstraper booter = new Bootstraper(
	new UnityDependencySuite(
		new UnityContainer()
			.AddExtension(
				new Diagnostic())));
booter.CreateApp();
booter.RunApp(args);