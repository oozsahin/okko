using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using okko.uzapi.Contracts;

namespace okko.uzapi.Controllers
{
    [Route("api/v{version:apiVersion}/deposits")]
    [ApiVersion("2.0")]
    [ApiController]
    public class HomeV2Controller : ControllerBase
    {
        private readonly ILoggerService _logger;

        public HomeV2Controller(ILoggerService logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets Values 
        /// </summary>
        /// <returns></returns>
        // GET: api/Home
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Accessed Home Controller");
            return new string[] { "value1", "value2" };
        }
        
    }
}
