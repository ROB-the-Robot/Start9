using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Start9.Api.Tools
{
	public static class Extensions
	{
		[DllImport("gdi32.dll")]
		static extern bool DeleteObject(IntPtr hObject);

		public static BitmapSource ToBitmapSource(this Bitmap bitmap)
		{
			if (bitmap == null)
				throw new ArgumentNullException(nameof(bitmap));

			var hBitmap = bitmap.GetHbitmap();

			try
			{
				return Imaging.CreateBitmapSourceFromHBitmap(
					hBitmap,
					IntPtr.Zero,
					Int32Rect.Empty,
					BitmapSizeOptions.FromEmptyOptions());
			}
			finally
			{
				DeleteObject(hBitmap);
			}
		}
	}
}