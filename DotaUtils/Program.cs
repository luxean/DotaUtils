using System;
using System.IO;
using System.Threading.Tasks;
using DotaUtils.ServerLogHandling;
using DotaUtils.RequestHandling;
using System.Linq;
using System.Text.Json;

namespace DotaUtils
{
    public class Program
    {
        public static readonly string ServerLogDir = @"C:\Program Files (x86)\Steam\steamapps\common\dota 2 beta\game\dota";
        public static readonly string ServerLogLoc = Path.Combine(ServerLogDir, "server_log.txt");
        public static async Task Main()
        {
            var playerIds = Parser.ParseLog(ServerLogLoc);
            if (playerIds.Count == 0)
            {
                return;
            }

            var tasks = playerIds.Select(playerId => new Requests(playerId).GetPlayer());
            var players = await Task.WhenAll(tasks);
            string jsonString = JsonSerializer.Serialize(players);
            File.WriteAllText(@"C:\Users\lukas\skola\4. semester\PV178\DotaUtils\DotaUtilsGUI\Jsons\match.json", jsonString);
        }
    }
}
