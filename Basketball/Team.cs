using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositin, char group)
        {
            Players = new List<Player>();
            Name = name;
            OpenPositions = openPositin;
            Group = group;
        }
        public List<Player> Players { get; set; }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count { get { return Players.Count; } }
        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }

            if (OpenPositions <= 0)
            {
                return "There are no more open positions.";

            }
            if (player.Rating<80)
            {
                return "Invalid player's rating.";
            }
            Players.Add(player);
            OpenPositions--;
            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";

        }
        public bool RemovePlayer(string name)
        {
           var current =Players.FirstOrDefault(p => p.Name == name);
            if (current == null)
            {
                return false;
            }
            Players.Remove(current);
            OpenPositions++;
            return true;
        }
        public int RemovePlayerByPosition(string position)
        {
            int removed=Players.RemoveAll(p => p.Position == position);
            OpenPositions+=removed;
            return removed;
        }
        public Player RetirePlayer(string name)
        {
            var player = Players.FirstOrDefault(p => p.Name == name);
            if (player==null)
            {
                return null;
            }
           player.Retired = true;
            return player;
            
        }
        public List<Player> AwardPlayers(int games)
        {
            return Players.Where(p=>p.Games >= games).ToList();
        }
        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Active players competing for Team {Name} from Group {Group}:");
            foreach (var item in Players.Where(x=>x.Retired!=true))
            {
                result.AppendLine(item.ToString());
            }
            return result.ToString().TrimEnd();
        }
    }
}
