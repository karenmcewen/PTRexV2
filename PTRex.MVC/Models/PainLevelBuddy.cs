using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PTRex.MVC.Models
{
    [MetadataType(typeof(PainLevelBuddy))]
    public partial class PainLevel
    {
    }

    internal sealed class PainLevelBuddy
    {
        public int ID { get; set; }

        [DisplayName("Pain Level:")]
        public string PainLevelName { get; set; }
            
    }
}