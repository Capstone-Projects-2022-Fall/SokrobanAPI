using SokrobanAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;



namespace SokrobanAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SokrobanController
    {
    }

    [HttpGet]
    [Route("SokLogin")]
    public SokrobanData SokLogin(string Username)
    {
        
    }
}
