using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace APIGroupProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketMasterController : ControllerBase
    {
        private readonly string APIKEYVARIABLE;
        public TicketMasterController(IConfiguration configuration)
        {
            APIKEYVARIABLE = configuration.GetSection("APIKeys")["TicketMasterAPI"];
        }
    }
}