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
    public class PlayersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Player> players = _context.Players.ToList();
            
            return View(players);
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var player = _context.Players.Where(p => p.Id == id);
            return View(player);
        }

        public IActionResult AddPicks(int id)
        {
            List<Matchup> matchups = null;
            var week = HttpDataHelper.Get_Current_Week();
            var picks = _context.PlayerPicks.Where(p => p.PlayerId == id && p.Week == week).FirstOrDefault();

            if (picks != null)
            {
                var player = _context.Players.Where(p => p.Id == id).FirstOrDefault();
                ViewBag.player = player;
                ViewBag.week = week;
                return View(matchups);
            }
            else
            {
                var player = _context.Players.Where(p => p.Id == id).FirstOrDefault();
                ViewBag.player = player;
                matchups = HttpDataHelper.Load_Matchups(HttpDataHelper.Get_Current_Week());
                ViewBag.week = week;
                return View(matchups);
                
            }
            
        }

       
        public IActionResult SavePicks(string[] teams, int id)
        {
            var week = HttpDataHelper.Get_Current_Week();
            PlayerPicks picks = new PlayerPicks(id, teams[0], teams[1], teams[2], teams[3], teams[4],
                                                teams[5], teams[6], teams[7], teams[8], teams[9], teams[10],
                                                teams[11], teams[12], teams[13], teams[14], teams[15], "2019", week);
            _context.Add(picks);
            _context.SaveChanges();
           
            return View();
        }

        public IActionResult AddPlayer()
        {
            return View();
        }

        public IActionResult ViewPicks(int id)
        {
            var week = HttpDataHelper.Get_Current_Week();
            var picks = _context.PlayerPicks.Where(p => p.PlayerId == id && p.Week == week).FirstOrDefault();

            var player = "";
            try
            {
                player = _context.Players.Where(n => n.Id == picks.PlayerId).Select(n => n.Username).FirstOrDefault();
            }
            catch (Exception ex)
            {
                player = "";
            }
            

            if (player != null)
            {
                ViewBag.player = player;
            }
            
            if (picks != null)
            {
                ViewBag.week = picks.Week;
                ViewBag.player = player;
                return View(picks);
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult EditPicks(int id)
        {
            List<Matchup> matchups = null;
            var player = _context.Players.Where(p => p.Id == id).FirstOrDefault();
            var week = HttpDataHelper.Get_Current_Week();
            var picks = _context.PlayerPicks.Where(p => p.PlayerId == id && p.Week == week).FirstOrDefault();

            if (picks != null)
            {
                ViewBag.player = player;
                matchups = HttpDataHelper.Load_Matchups(HttpDataHelper.Get_Current_Week());
                ViewBag.week = week;
                return View(matchups);
               
            }
            else
            {
                ViewBag.player = player;
                ViewBag.week = week;
                return View(matchups);

            }
            
        }
    }
}