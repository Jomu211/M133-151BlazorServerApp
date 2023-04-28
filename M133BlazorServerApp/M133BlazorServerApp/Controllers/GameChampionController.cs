using BootstrapBlazor.Components;
using M133BlazorServerApp.M151Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;

namespace M133BlazorServerApp.Controllers
{
    [Route("[controller]")]
    public class GameChampionController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult Index()
        {
            using (var db = new M151DbContext())
            {
                var champions = db.GameChampions.ToList();
                return View("Index", champions);
            }
        }

        public List<GameChampion> GetChampionsWithRegion(string region)
        {
            using(var db = new M151DbContext())
            {
                return db.GameChampions.Where(c => c.Region == region).ToList();
            }
        }
        public bool CheckIfChosenChampion(GameChampion champion)
        {
            using (var db = new M151DbContext())
            {
                return db.GameChampions.Any(c => c.ChosenChampion && c.Id == champion.Id);
            }
        }
    }
}
