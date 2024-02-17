using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Globalization;

namespace DotaUtilsGUI
{
	public class StringToHeroImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo _)
		{
			if (value == null)
            {
				value = "NaN";
            }
			return new BitmapImage(new Uri("/DotaUtilsGUI;component/Images/" + value.ToString() + ".png", UriKind.Relative));
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo _)
		{
			throw new NotImplementedException();
		}
	}
}
