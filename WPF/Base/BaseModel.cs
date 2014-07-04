using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.Annotations;

namespace WPF.Base
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
