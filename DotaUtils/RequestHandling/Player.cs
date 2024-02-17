using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotaUtils.RequestHandling
{
    public class Player
    {
        public PlayerInfo Info { get; set; }
        public List<MatchInfo> RecentMatches { get; set; }
        public List<HeroInfo> Heroes { get; set; }
        public List<HeroInfo> RecentHeroes { get; set; }
        public WL WinLose { get; set; }
        public Counts RecentCounts { get; set; }

        [JsonIgnore]
        public bool HasPublicProfile
        {
            get
            {
                return Info != null;
            }
            set { }
        }
        public Player() { }
        public Player(PlayerInfo info, List<MatchInfo> matches, List<HeroInfo> heroes, List<HeroInfo> recentHeroes, WL winLose, Counts recentCounts)
        {
            Info = info;
            RecentMatches = matches;
            Heroes = heroes;
            RecentHeroes = recentHeroes;
            WinLose = winLose;
            RecentCounts = recentCounts;
        }
    }
}
