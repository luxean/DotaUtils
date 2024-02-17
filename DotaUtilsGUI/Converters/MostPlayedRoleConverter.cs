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
    public class MostPlayedRoleConverter: IValueConverter
    {
		public object Convert(object value, Type targetType, object parameter, CultureInfo _)
		{
			var roles = (LaneRole)value;
			_0[] vals = { roles.Safe, roles.Mid, roles.Off, roles.Jungle };
			int idx = -1;
			int? maxGames = -1;
			for (int i = 0; i < 4; ++i)
            {
				if (vals[i] != null && vals[i].Games > maxGames)
                {
					maxGames = vals[i].Games;
					idx = i;
                }
            }
			return idx switch
			{
				-1 => "Unknown",
				0 => "Safelane",
				1 => "Midlane",
				2 => "Offlane",
				3 => "Jungle"
			};
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo _)
		{
			throw new NotImplementedException();
		}
	}
}
