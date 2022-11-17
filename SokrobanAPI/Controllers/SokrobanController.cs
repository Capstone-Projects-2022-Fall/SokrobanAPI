using SokrobanAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Drawing;

namespace SokrobanAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SokrobanController
    {

        private readonly Models.DatabaseContext _context;
        private readonly ILogger<SokrobanController> _logger;

        public SokrobanController(DatabaseContext context, ILogger<SokrobanController> logger)
        {
            _context = context;
            _logger = logger;
        }   

        [HttpPost]
        [Route("SokLogin")] //Insert Login info (Sign-up)
        public SokLogin SokLogin(string Username, string Password)
        {
            _context.Database.ExecuteSqlRaw("insert into PlayerInfo(Username,Password) values({0},{1})",Username,Password);

            SokLogin sok = new SokLogin();
            sok.Username = Username;
            sok.Password = Password;
            return sok;

        }

        [HttpPost]
        [Route("SokLevelInsert")] //Insert Level Data
        public SokLevel LevelInsert(string ? Username,int Score,int Time,int Level)
        {
            _context.Database.ExecuteSqlRaw("insert into LevelStats(Username,Score,Time,Level) values({0},{1},{2},{3})", Username,Score, Time,Level);

            SokLevel sok = new SokLevel();
            sok.Username = Username;
            sok.Score = Score;
            sok.Time = Time;
            sok.Level = Level;  
            return sok;

        }

        [HttpGet]
        [Route("SokStatsInst")] 
        public SokStats StatInsert(string Username,int Level, int Highscore, int BestTime)
        {
            _context.Database.ExecuteSqlRaw("insert into PlayerStats(Username,Level,Highscore,BestTime) values({0},{1},{2},{3})", Username, Level, Highscore, BestTime);

            SokStats sok = new SokStats();
            sok.Username = Username;
            sok.Level = Level;
            sok.Highscore = Highscore;
            sok.BestTime = BestTime;
            return sok;

        }

        [HttpGet]
        [Route("SokLevel")] //Return level info
        public List<SokLevel> Levelinfo()
        {
            return _context.sokLevel.ToList();    
        }

        [HttpGet]
        [Route("SokStats")] //Return PlayerStats
        public List<SokStats> Stats()
        {
            return _context.sokStats.ToList();
        }

        [HttpGet]
        [Route("PasswordCheck")]
        public List<SokLogin> SignIn()
        {
            return _context.sokLogin.ToList();
        }

        [HttpGet]
        [Route("Check")]
        public List<SokLogin> SignInCheck(string usr)
        {   
            return (from d in _context.sokLogin
                    where d.Username == usr
                    select d).OrderBy(u => u.Username).ToList(); ;
        }

    }
}
