using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using HangfireExampleCore.Core.Demo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangfireExampleCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {
        private IDemoService _demoService;

        public HangfireController(IDemoService demoService)
        {
            _demoService = demoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            RecurringJob.AddOrUpdate("demo-job", () => _demoService.RunDemoTask(), Cron.Minutely);
            return Ok();
        }
    }
}