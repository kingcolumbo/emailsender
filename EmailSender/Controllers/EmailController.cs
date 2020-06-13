using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using EmailSender.Models;
using EmailSender.Services;

namespace EmailSender.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : Controller
    {

        [HttpPost("[action]/{e}")]
        public IActionResult SendEmail([FromBody]EmailMessage e)
        {
            EmailService es = new EmailService(e);
            return Ok(es.SendEmail());
        }      
    }
}