using System.Drawing;
using System.Windows.Media;
using SAMStock.BO;
using SAMStock.Business;
using SAMStock.Business.Foundation;
using SAMStock.Business.Objects;
using Util.Collections;

namespace WPF
{
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
			new Singleton<IManager<Component>>(SAMStock.Dispatcher.Resolve<IManager<Component>>());
			new Singleton<IManager<Pedal>>(SAMStock.Dispatcher.Resolve<IManager<Pedal>>());
			new Singleton<IManager<Supplier>>(SAMStock.Dispatcher.Resolve<IManager<Supplier>>());
			new Singleton<Config>(SAMStock.Dispatcher.Resolve<Config>());
		}
	}
}