using System.ComponentModel.DataAnnotations;

namespace PTRex.MVC.Models
{
    [MetadataType(typeof(TargetWorkoutMetadata))]
    public partial class TargetWorkout
    {
    }

    internal sealed class TargetWorkoutMetadata
    {
        //table columns
        [Display(Name = "# Sessions")]
        [Range(0, 1)]
        [Required]
        public int TargetSessionsPerDay { get; set; }

        [Display(Name = "# Sets")]
        [Range(1, 3)]
        [Required]
        public int TargetNumSets { get; set; }

        [Display(Name = "# Reps")]
        [Range(1, 20)]
        [Required]
        public int TargetNumReps { get; set; }


        [Display(Name = "Notes")]
        [Required]
        public string TargetNotes { get; set; }



    }
}