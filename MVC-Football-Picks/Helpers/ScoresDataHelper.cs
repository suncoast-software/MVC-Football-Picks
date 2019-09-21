using MVC_Football_Picks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Football_Picks.Models;

namespace MVC_Football_Picks.Helpers
{
    public class ScoresDataHelper
    {
        //private field for the database context
        private readonly ApplicationDbContext dbContext;

        //constructor to set the db context
        public ScoresDataHelper(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public static List<string> Get_Matchup_Winners(string week)
        {
            List<Matchup> scores = HttpDataHelper.Get_Week_Scores(week);
            List<string> winners = new List<string>();

            foreach (var matchup in scores)
            {
                bool resAway;
                bool resHome;

                resAway = int.TryParse(matchup.AwayScore, out int awayScore);
                resHome = int.TryParse(matchup.HomeScore, out int homeScore);

                if (resAway == true && resHome == true)
                {
                    if (awayScore > homeScore)
                    {
                        winners.Add(matchup.AwayTeam);
                    }
                    else
                        winners.Add(matchup.HomeTeam);
                }
                else
                {
                    return winners;
                }
             
            }
            return winners;
        }
    }
}
