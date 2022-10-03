using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SokrobanAPI.Models
{
    [Table("PlayerInfo")]
    public class SokrobanData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int ? Highscore { get; set; }
        public DateTime ? BestTime { get; set; }
        public int ? Level { get; set; }
    }
}
