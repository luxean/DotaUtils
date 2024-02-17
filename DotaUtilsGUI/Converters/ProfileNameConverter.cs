using DotaUtils.RequestHandling;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DotaUtilsGUI
{
    public class ProfileNameConverter : IValueConverter
    {
		public object Convert(object value, Type targetType, object parameter, CultureInfo _)
		{
			var info = (Profile)value;
			if (info == null)
            {
				return "Public data not available";
            }
			return info.Personaname;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo _)
		{
			throw new NotImplementedException();
		}
	}
}
