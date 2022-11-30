using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SokrobanAPI.Models
{
   
    [Table("PLayerInfo")]
    public class SokLogin
    {
        [Key]
        public string? Username { get; set; }
        public string? Password { get; set; }
    }


    [Table("LevelStats")]
    public class SokLevel
    {
        [Key]
        public int Level { get; set; }
        public string? Username { get; set; }
        public int Score { get; set; }
        public int Time { get; set; }
    }

    [Table("SaveData")]
    public class SokSave
    {
        public string? Username { get; set; }
        public int Level { get; set; }
        public int Score { get; set; }
        public int Time { get; set; }
    }

    [Table("PlayerStats")]
    public class SokStats
    {
        public string? Username { get; set; }
        public int Level { get; set; }
        public int Highscore { get; set; }
        public int BestTime { get; set; }
    }

    [Serializable]
    [Table("LoginCheck")]
    public class SokUser  
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

}
