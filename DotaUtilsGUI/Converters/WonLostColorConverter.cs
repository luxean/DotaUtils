using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;

namespace DotaUtilsGUI
{
    public class WonLostColorConverter: IValueConverter
    {
		private static readonly byte Alpha = 0xB3;
		public object Convert(object value, Type targetType, object parameter, CultureInfo _)
		{
			if (value == null)
            {
				return Color.FromArgb(Alpha, 0, 0, 0);
            }

			var won = (bool) value;
			return won switch { true => Color.FromArgb(Alpha, 0, 255, 0), false => Color.FromArgb(Alpha, 255, 0, 0) };
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo _)
		{
			throw new NotImplementedException();
		}
	}
}
