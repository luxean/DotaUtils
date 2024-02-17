using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DotaUtilsGUI
{
    public class IdToLinkConverter: IValueConverter
    {
		public object Convert(object value, Type targetType, object parameter, CultureInfo _)
		{
			return "https://www.opendota.com/players/" + value.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo _)
		{
			throw new NotImplementedException();
		}
	}
}
