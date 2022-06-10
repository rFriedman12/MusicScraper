using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicScraper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicScraper.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        [Route("getall")]
        public List<MusicCd> GetMusicCds()
        {
            return ScrapeMusic.Srape();
        }
    }
}
