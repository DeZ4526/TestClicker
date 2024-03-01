using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
	[SerializeField] private ClickerController clickerController;
	[SerializeField] private WindowsController windowsController;
	[SerializeField] private ShopController shopController;

	public override void InstallBindings()
	{
		Container.Bind<IMoney>().FromInstance(clickerController);
		Container.Bind<WindowsController>().FromInstance(windowsController);
		Container.Bind<ShopController>().FromInstance(shopController);
		Container.Bind<IDifferenceSettings>().FromInstance(clickerController);
	}
}