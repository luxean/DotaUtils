using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotaUtils.RequestHandling
{
    public class Profile
    {
        [JsonPropertyName("account_id")]
        public int? AccountId { get; set; }

        [JsonPropertyName("personaname")]
        public string Personaname { get; set; }

        [JsonPropertyName("name")]
        public object Name { get; set; }

        [JsonPropertyName("plus")]
        public bool? Plus { get; set; }

        [JsonPropertyName("cheese")]
        public int? Cheese { get; set; }

        [JsonPropertyName("steamid")]
        public string Steamid { get; set; }

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        [JsonPropertyName("avatarmedium")]
        public string Avatarmedium { get; set; }

        [JsonPropertyName("avatarfull")]
        public string Avatarfull { get; set; }

        [JsonPropertyName("profileurl")]
        public string Profileurl { get; set; }

        [JsonPropertyName("last_login")]
        public DateTime? LastLogin { get; set; }

        [JsonPropertyName("loccountrycode")]
        public string Loccountrycode { get; set; }

        [JsonPropertyName("is_contributor")]
        public bool? IsContributor { get; set; }
    }

    public class MmrEstimate
    {
        [JsonPropertyName("estimate")]
        public int? Estimate { get; set; }
    }

    public class PlayerInfo
    {
        [JsonPropertyName("tracked_until")]
        public string TrackedUntil { get; set; }

        [JsonPropertyName("competitive_rank")]
        public object CompetitiveRank { get; set; }

        [JsonPropertyName("solo_competitive_rank")]
        public object SoloCompetitiveRank { get; set; }

        [JsonPropertyName("rank_tier")]
        public int? RankTier { get; set; }

        [JsonPropertyName("profile")]
        public Profile Profile { get; set; }

        [JsonPropertyName("leaderboard_rank")]
        public object LeaderboardRank { get; set; }

        [JsonPropertyName("mmr_estimate")]
        public MmrEstimate MmrEstimate { get; set; }
    }
}
