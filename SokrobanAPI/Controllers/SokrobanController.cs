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
using Newtonsoft.Json;

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

        [HttpGet]
        [Route("SignUp")]
        public SokLogin SignUp(string Username, string Password)
        {
            _context.Database.ExecuteSqlRaw("insert into PlayerInfo(Username,Password) values({0},{1})", Username, Password);

            SokLogin login = new SokLogin();
            login.Username = Username;
            login.Password = Password;  
            return login;
        }

        [HttpGet]
        [Route("Login")]
        public List<SokUser> Login(string usr)
        {
            return (from d in _context.sokUser
                    where d.Username == usr
                    select d).OrderBy(u => u.Username).ToList();
        }

        [HttpGet]
        [Route("SokSave")] //SaveslevelData
        public SokSave Save(string Username, int Level, int Score, int Time)
        {
            _context.Database.ExecuteSqlRaw("insert into SaveData(Username,Level,Score,Time) values({0},{1},{2},{3})", Username,Score,Time,Level);

            SokSave save = new SokSave();
            save.Username = Username;
            save.Level = Level;
            save.Score = Score;
            save.Time = Time;
            return save;
        }

        [HttpGet]
        [Route("LevelData")] //Return level info
        public List<SokLevel> Levelinfo(string usr)
        {
            return (from d in _context.sokLevel
                    where d.Username == usr
                    select d).OrderBy(u => u.Username).ToList();
        }

        //[HttpGet]
        //[Route("SokStatsInst")] 
        //public SokStats StatInsert(string Username,int Level, int Highscore, int BestTime)
        //{
        //    _context.Database.ExecuteSqlRaw("insert into PlayerStats(Username,Level,Highscore,BestTime) values({0},{1},{2},{3})", Username, Level, Highscore, BestTime);

        //    SokStats sok = new SokStats();
        //    sok.Username = Username;
        //    sok.Level = Level;
        //    sok.Highscore = Highscore;
        //    sok.BestTime = BestTime;
        //    return sok;

        //}

        //[HttpGet]
        //[Route("SokStats")] //Return PlayerStats
        //public List<SokStats> Stats()
        //{
        //    return _context.sokStats.ToList();
        //}

    }
}
