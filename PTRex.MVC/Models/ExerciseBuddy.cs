using System.ComponentModel.DataAnnotations;

namespace PTRex.MVC.Models
{
    [MetadataType(typeof(ExerciseBuddy))]
    public partial class Exercise
    {
    }

    sealed class ExerciseBuddy
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [Display(Name = "How To")]
        public string HowTo { get; set; }

        public string Equipment { get; set; }

        [Display(Name = "Video")]
        public string ResourceVideo { get; set; }

        [Display(Name = "Photo")]
        public string ResourcePhoto { get; set; }

        [Display(Name = "Tips")]
        public string ResourceText { get; set; }
    }
}