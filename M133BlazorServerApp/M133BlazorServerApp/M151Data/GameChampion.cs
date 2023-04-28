using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M133BlazorServerApp.M151Data
{
    public class GameChampion
    {
        public int Id { get; set; }
        [Display(Name ="Name")]
        public string ChampionName { get; set; }
        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }
        public string? Region { get; set; }
        [Display(Name = "Gender")]
        public string? Geschlecht { get; set; }
        [Display(Name = "Combat Style")]
        public string? Kampfart { get; set; }
        public bool ChosenChampion { get; set; }
        public virtual Head Head { get; set; }
    }
}
