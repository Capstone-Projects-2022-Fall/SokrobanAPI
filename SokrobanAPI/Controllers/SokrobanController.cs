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

        [HttpGet]
        [Route("SokLogin")]
        public SokLogin SokLogin(string Username, string Password)
        {
            //_context.Database.ExecuteSqlRaw();

            SokLogin sok = new SokLogin();
            sok.Username = Username;
            sok.Password = Password;
            return sok;

        }

        [HttpGet]
        [Route("SokStats")]
        public List<SokStats> task()
        {
            var SokData = (from d in _context.sokStats
                           select d).OrderBy(H => H.Highscore).ToList();
            return SokData;
        }

        // Levels have been removed from application, for now
        //[HttpGet]
        //[Route("SokLevel")]
        //public List<SokLevel> task()
        //{
        //    var SokLev = (from d in _context.sokLevel
        //                   select d).OrderBy(L => L.Level).ToList();
        //    return SokLev;
        //}



    }
}
