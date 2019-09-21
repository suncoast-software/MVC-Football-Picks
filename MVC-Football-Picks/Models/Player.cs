using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Football_Picks.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public Player(int id, string role, string username, string email, string phoneNumber)
        {
            Id = id;
            Role = role;
            Username = username;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
