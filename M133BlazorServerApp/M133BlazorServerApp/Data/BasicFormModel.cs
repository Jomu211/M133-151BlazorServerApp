using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace M133BlazorServerApp.Data
{
    public class BasicFormModel
    {
        [Required]
        [StringLength(15,ErrorMessage = "Shorten this")]
        [DisplayName("Champion Name")]
        public string champName { get; set; }
        [Required]
        [DisplayName("Champion Description")]
        public string champDescription { get; set; }
        [Required]
        [DisplayName("Champion Found")]
        public bool champFound { get; set; }
        [Required]
        [DisplayName("Champion release date")]
        public DateTime champReleaseDate { get; set; }

    }
}
