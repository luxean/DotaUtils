using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotaUtils.RequestHandling
{
    public class WL
    {
        [JsonPropertyName("win")]
        public int? Win { get; set; }

        [JsonPropertyName("lose")]
        public int? Lose { get; set; }

        [JsonIgnore]
        public int? Total
        {
            get
            {
                if (Win == null || Lose == null)
                {
                    return null;
                }
                return Win + Lose;
            }
            set { }
        }

        public int? WinRate
        {
            get
            {
                if (Win == null || Lose == null || Total == null || Total == 0)
                {
                    return null;
                }
                return (Win * 100) / Total;
            }
            set { }
        }
    }
}
