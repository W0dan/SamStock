using System.ComponentModel;
using System.Runtime.CompilerServices;
using SAMStock.wpf.Annotations;

namespace SAMStock.wpf.Base
{
	public class BaseModel: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		[NotifyPropertyChangedInvocator]
		protected void RaisePropertyChanged([CallerMemberName] string propertyname = null)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
		}
	}
}
