using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Football_Picks.Models
{
    public class Matchup
    {
        public int Id { get; set; }
        public string AwayTeam { get; set; }
        public string AwayRecord { get; set; }
        public string AwayScore { get; set; }
        public string HomeTeam { get; set; }
        public string HomeRecord { get; set; }
        public string HomeScore { get; set; }
        public string Year { get; set; }
        public string Week { get; set; }

        public bool AwayChecked { get; set; }
        public bool HomeChecked { get; set; }

        public Matchup()
        {
        }

        public Matchup(string awayTeam, string awayRecord, string awayScore, string homeTeam, 
            string homeRecord, string homeScore, string year, string week)
        {
            AwayTeam = awayTeam;
            AwayRecord = awayRecord;
            AwayScore = awayScore;
            HomeTeam = homeTeam;
            HomeRecord = homeRecord;
            HomeScore = homeScore;
            Year = year;
            Week = week;
        }
    }
}
