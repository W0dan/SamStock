using System.Drawing;
using System.Windows.Media;
using SAMStock.BO;
using SAMStock.BO.Foundation;
using Util.Collections;

namespace WPF
{
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
			new Singleton<IBOManager<Component>>(SAMStock.Dispatcher.Resolve<IBOManager<Component>>());
			new Singleton<IBOManager<Pedal>>(SAMStock.Dispatcher.Resolve<IBOManager<Pedal>>());
			new Singleton<IBOManager<Supplier>>(SAMStock.Dispatcher.Resolve<IBOManager<Supplier>>());
			new Singleton<Config>(SAMStock.Dispatcher.Resolve<Config>());
		}
	}
}