using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Football_Picks.Models
{
    public class MatchupWinner
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public string Winner { get; set; }
        public string PlayerPick { get; set; }
        public bool Win { get; set; }
        public string Week { get; set; }

        public MatchupWinner(string playerName, string winner, string playerPick, bool win, string week)
        {
            PlayerName = playerName;
            Winner = winner;
            PlayerPick = playerPick;
            Win = win;
            Week = week;
        }

    }
}
