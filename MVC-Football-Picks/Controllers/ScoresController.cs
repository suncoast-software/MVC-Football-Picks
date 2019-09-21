using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Football_Picks.Data;
using MVC_Football_Picks.Helpers;
using MVC_Football_Picks.Models;

namespace MVC_Football_Picks.Controllers
{
    public class ScoresController : Controller
    {
        ApplicationDbContext _context;
        private string week;

        public ScoresController(ApplicationDbContext context)
        {
            _context = context;
            week = HttpDataHelper.Get_Current_Week();
        }

        //Get
        public IActionResult Scores()
        {
            List<Matchup> scores = HttpDataHelper.Get_Week_Scores(week);
            ViewBag.week = week;
            return View(scores);
        }

        //Post
        [HttpPost]
        public IActionResult Scores(string search)
        {
            List<Matchup> scores = HttpDataHelper.Get_Week_Scores(search);
            ViewBag.week = search;
            return View(scores);
        }

        public IActionResult CalculateWins(int id)
        {
            List<MatchupWinner> matchupWinnerList = new List<MatchupWinner>();
            string week = HttpDataHelper.Get_Current_Week();
            int scoreCount = 0;
            var player = _context.Players.Where(p => p.Id == id).FirstOrDefault();

            List<string> winners = ScoresDataHelper.Get_Matchup_Winners("1");
            var picks = _context.PlayerPicks.Where(p => p.PlayerId == id && p.Week == "1").FirstOrDefault();
            string[] playerPicks = new string[] { picks.Pick1, picks.Pick2, picks.Pick3, picks.Pick4, picks.Pick5, picks.Pick6, picks.Pick7, picks.Pick8,
                                                    picks.Pick9, picks.Pick10, picks.Pick11, picks.Pick12, picks.Pick13, picks.Pick14, picks.Pick15, picks.Pick16 };
            int index = 0;
            foreach (var pick in playerPicks)
            {
              
                string winner = winners[index].Trim();
                if (winner.Equals(pick.Trim()))
                {
                    matchupWinnerList.Add(new MatchupWinner(player.Username, winner, pick, true, week));
                    scoreCount++;
                }
                else
                    matchupWinnerList.Add(new MatchupWinner(player.Username, winner, pick, false, week));

                index++;
            }
            ViewBag.scorecount = scoreCount;
            return View(matchupWinnerList);
        }
    }
}