using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotaUtils.ServerLogHandling
{
    public static class Parser
    {
        private static readonly Regex LobbyPattern = new(@"\(Lobby[^P]*\)", RegexOptions.Compiled);
        private static readonly Regex PlayersPattern = new(@"\d+:\[U:\d:(\d*)\]", RegexOptions.Compiled);

        public static List<string> ParseLog(string path)
        {
            string lastLine = File.ReadLines(path).Last();

            var lobbyMatch = LobbyPattern.Match(lastLine);
            if (!lobbyMatch.Success)
            {
                return new();
            }

            var matches = PlayersPattern.Matches(lobbyMatch.Value);
            if (matches.Count < 10)
            {
                return new();
            }

            return matches.Select(playerMatch => playerMatch.Groups[1].Value).Take(10).ToList();
        }
    }
}
