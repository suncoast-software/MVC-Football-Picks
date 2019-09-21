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
    public class PlayerPicksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerPicksController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Get
        public IActionResult Index()
        {
            var players = _context.Players.ToList();
            
            return View(players);
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult ViewPicks(int id)
        {
            var week = HttpDataHelper.Get_Current_Week();
            var picks = _context.PlayerPicks.Where(p => p.PlayerId == id && p.Week == week).FirstOrDefault();
            var player = _context.Players.Where(p => p.Id == id).FirstOrDefault();
            ViewBag.player = player;
            return View(picks);
        }
    }
}