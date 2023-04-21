using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace M133BlazorServerApp.Data
{
    public class ChampionQuizModel
    {
        [DisplayName("Champion Name")]
        public string Name { get; set; }
        public string Gender {get; set; }
        public string Position { get; set; }
        public string Resource { get; set; }
        public string RangeType { get; set; }
    }
}
