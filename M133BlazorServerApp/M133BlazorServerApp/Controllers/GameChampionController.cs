using BootstrapBlazor.Components;
using M133BlazorServerApp.M151Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System;

namespace M133BlazorServerApp.Controllers
{
    [Route("[controller]")]
    public class GameChampionController : Controller
    {


        [HttpGet("[action]")]
        public IActionResult ChampionPartial()
        {
            using (var db = new M151DbContext())
            {
                var champions = db.GameChampions.ToList();
                db.GameChampions.Include(r => r.Head).ToList();
                return View("Index", champions);
            }
        }
        public async Task<List<GameChampion>> GetAllEmployeesAsync()
        {
            using (var db = new M151DbContext())
            {
                return await db.GameChampions.ToListAsync();

            }
        }
        public List<GameChampion> GetChampionsWithRegion(string region)
        {
            using (var db = new M151DbContext())
            {
                return db.GameChampions.Where(c => c.Region == region).ToList();
            }
        }
     
    }
}
