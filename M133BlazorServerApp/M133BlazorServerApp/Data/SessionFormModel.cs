using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace M133BlazorServerApp.Data
{
    public class SessionFormModel
    {
        [Required]
        [DisplayName("Champion Name")]
        public string champName { get; set; }
        [Required]
        [DisplayName("Champion Age")]
        public bool champGen { get; set; }
    }
}