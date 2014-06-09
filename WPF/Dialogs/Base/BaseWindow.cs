using System;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SAMStock.wpf.Dialogs.Base
{
	public class BaseWindow: Window
	{
		public BaseWindow()
		{
			Icon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.SAMStock.ToBitmap().GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
		}
		public BaseWindow(BaseDialog content): this()
		{
			content.RegisterWindow(this);
			Content = content;
			SizeToContent = SizeToContent.WidthAndHeight;
		}
	}
}
