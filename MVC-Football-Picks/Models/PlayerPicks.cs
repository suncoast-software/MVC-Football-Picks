using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Football_Picks.Models
{
    public class PlayerPicks
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public Player Player { get; set; }

        public string Pick1 { get; set; }
        public string Pick2 { get; set; }
        public string Pick3 { get; set; }
        public string Pick4 { get; set; }
        public string Pick5 { get; set; }
        public string Pick6 { get; set; }
        public string Pick7 { get; set; }
        public string Pick8 { get; set; }
        public string Pick9 { get; set; }
        public string Pick10 { get; set; }
        public string Pick11 { get; set; }
        public string Pick12 { get; set; }
        public string Pick13 { get; set; }
        public string Pick14 { get; set; }
        public string Pick15 { get; set; }
        public string Pick16 { get; set; }

        public string Year { get; set; }
        public string Week { get; set; }

        public PlayerPicks(int playerId, string pick1, string pick2, string pick3, string pick4, 
                             string pick5, string pick6, string pick7, string pick8, string pick9, string pick10, 
                             string pick11, string pick12, string pick13, string pick14, string pick15, string pick16, string year, string week)
        {
            PlayerId = playerId;
            Pick1 = pick1;
            Pick2 = pick2;
            Pick3 = pick3;
            Pick4 = pick4;
            Pick5 = pick5;
            Pick6 = pick6;
            Pick7 = pick7;
            Pick8 = pick8;
            Pick9 = pick9;
            Pick10 = pick10;
            Pick11 = pick11;
            Pick12 = pick12;
            Pick13 = pick13;
            Pick14 = pick14;
            Pick15 = pick15;
            Pick16 = pick16;
            Year = year;
            Week = week;
        }
    }
}
