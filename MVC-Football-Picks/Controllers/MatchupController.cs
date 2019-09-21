using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Football_Picks.Data;
using MVC_Football_Picks.Helpers;
using MVC_Football_Picks.Models;

namespace MVC_Football_Picks.Controllers
{
    public class MatchupController : Controller
    {
        ApplicationDbContext _context;
        string week; 

        public MatchupController(ApplicationDbContext context)
        {
            _context = context;
            week = HttpDataHelper.Get_Current_Week();
        }

        [HttpGet]
        public IActionResult Matchup()
        {
            List<Matchup> matchups = HttpDataHelper.Load_Matchups(week);
            ViewBag.week = week;
            return View(matchups);
        }

        [HttpPost]
        public IActionResult Matchup(string search)
        {
           
            //List<Matchup> scores = HttpDataHelper.Get_Week_Scores(week);
            List<Matchup> matchups = HttpDataHelper.Load_Matchups(search);
            ViewBag.week = search;
            return View(matchups);
        }
    }
}