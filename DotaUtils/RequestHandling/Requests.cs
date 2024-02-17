using RestSharp;
using RestSharp.Serializers.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaUtils.RequestHandling
{
    public class Requests
    {
        private readonly RestClient Client = new ("https://api.opendota.com/api");
        private readonly string ClientId;

        public Requests(string clientId)
        {
            ClientId = clientId;
            Client.UseSystemTextJson();
        }

        private async Task<T> GetInfoBase<T>(string strRequest, params (string, string)[] parameters)
        {
            var request = new RestRequest("players/{account_id}/" + strRequest);
            request.AddUrlSegment("account_id", ClientId);
            foreach (var (param, val) in parameters)
            {
                request.AddParameter(param, val);
            }
            var response = await Client.GetAsync<T>(request);
            return response;
        }

        public Task<PlayerInfo> GetPlayerInfo()
        {
            return GetInfoBase<PlayerInfo>("");
        }

        public Task<List<MatchInfo>> GetPlayerMatches()
        {
            return GetInfoBase<List<MatchInfo>>("recentMatches");
        }

        public Task<List<HeroInfo>> GetPlayerHeroes()
        {
            return GetInfoBase<List<HeroInfo>>("heroes", ("having", "20"));
        }

        public Task<List<HeroInfo>> GetPlayerHeroesRecent()
        {
            return GetInfoBase<List<HeroInfo>>("heroes", ("having", "5"), ("date", "90"));
        }

        public Task<WL> GetPlayerWL()
        {
            return GetInfoBase<WL>("wl");
        }

        public Task<Counts> GetPlayerCountsRecent()
        {
            return GetInfoBase<Counts>("counts", ("date", "90"));
        }

        public async Task<Player> GetPlayer()
        {
            var info = GetPlayerInfo();
            var matches = GetPlayerMatches();
            var heroes = GetPlayerHeroes();
            var recentHeroes = GetPlayerHeroesRecent();
            var winLose = GetPlayerWL();
            var recentCounts = GetPlayerCountsRecent();
            return new Player(await info, (await matches).Take(15).ToList(), await heroes, await recentHeroes, await winLose, await recentCounts);
        }
    }
}
