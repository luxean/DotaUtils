using RestSharp;
using RestSharp.Extensions;
using RestSharp.Serializers.SystemTextJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroImages
{
    public static class HeroImagesGetter
    {
        private static readonly RestClient ClientODota = new("https://api.opendota.com/api");
        private static readonly RestClient ClientImages = new("http://cdn.dota2.com/apps/dota2/images/heroes");
        private static readonly string SavePath = @"C:\Users\lukas\skola\4. semester\PV178\DotaUtilsGUI\DotaUtils\Images";
        public static void GetHeroImages()
        {
            ClientODota.UseSystemTextJson();
            var requestHeroes = new RestRequest("heroes");
            var response = ClientODota.Get<List<Hero>>(requestHeroes);

            foreach (Hero hero in response.Data)
            {
                var requestImage = new RestRequest(hero.Name.Replace("npc_dota_hero_", "") + "_sb.png", Method.GET);
                var bytes = ClientImages.DownloadData(requestImage);
                File.WriteAllBytes(Path.Combine(SavePath, hero.Id.ToString() + ".png"), bytes);
            }
        }
    }
}
