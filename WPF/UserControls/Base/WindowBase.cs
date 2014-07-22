using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace WPF.UserControls.Base
{
	public class WindowBase: Window
	{
		public WindowBase()
		{
			Icon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.SAMStock.ToBitmap().GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
		}
		public WindowBase(DialogBase content): this()
		{
			content.RegisterWindow(this);
			Content = content;
			SizeToContent = SizeToContent.WidthAndHeight;
		}
	}
}
