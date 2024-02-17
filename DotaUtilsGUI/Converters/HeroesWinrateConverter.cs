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
	public class HeroesWinrateConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo _)
		{
			var heroes = (List<HeroInfo>)value;
			return heroes.OrderByDescending(heroInfo => heroInfo.WinRate).Take(3).ToList();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo _)
		{
			throw new NotImplementedException();
		}
	}
}
