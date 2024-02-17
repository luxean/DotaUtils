using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotaUtils.RequestHandling
{
    public class HeroInfo
    {
        [JsonPropertyName("hero_id")]
        public string HeroId { get; set; }

        [JsonPropertyName("last_played")]
        public int? LastPlayed { get; set; }

        [JsonPropertyName("games")]
        public int? Games { get; set; }

        [JsonPropertyName("win")]
        public int? Win { get; set; }

        [JsonPropertyName("with_games")]
        public int? WithGames { get; set; }

        [JsonPropertyName("with_win")]
        public int? WithWin { get; set; }

        [JsonPropertyName("against_games")]
        public int? AgainstGames { get; set; }

        [JsonPropertyName("against_win")]
        public int? AgainstWin { get; set; }

        [JsonIgnore]
        public int? WinRate
        {
            get
            {
                if (Games == null || Win == null)
                {
                    return null;
                }
                return (Win * 100) / Games;
            }
            set { }
        }
    }
}
