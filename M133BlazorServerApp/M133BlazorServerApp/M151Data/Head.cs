using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M133BlazorServerApp.M151Data
{
    public class Head
    {
        public int Id { get; set; }
        [Display(Name = "Hair Color")]
        public string? Haaresfarbe { get; set; }
        [Display(Name = "Headgear")]
        public string? Kopfbedeckung { get; set; }
        [Display(Name = "Other")]
        public string? Anderes { get; set; }
        [ForeignKey("GameChampion")]
        public int? GameChampionId { get; set; }
        public virtual GameChampion GameChampion { get; set; }
    }
}
