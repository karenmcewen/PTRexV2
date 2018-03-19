using System.ComponentModel.DataAnnotations;

namespace PTRex.MVC.Models
{
    [MetadataType(typeof(ActualWorkoutBuddy))]
    public partial class ActualWorkout
    {
    }

    public class ActualWorkoutBuddy
    {
        [Display(Name = "Actual #Sets")]
        [Required]
        public int ActualNumSets { get; set; }

        [Display(Name = "Actual #Reps")]
        [Required]
        public int ActualNumReps { get; set; }

        [Display(Name = "Workout Date")]
        [DataType(DataType.Date)]
        [Required]
        public System.DateTime Date { get; set; }


        public int TimeOfDayID { get; set; }

        [Display(Name = "Weight Used")]
        public string WeightUsed { get; set; }


        public int PainLevelID { get; set; }

        [Display(Name = "Notes")]
        public string ActualNotes { get; set; }

        [Display(Name = "Pain Level")]
        public virtual PainLevel PainLevel { get; set; }

        [Display(Name = "Target")]
        public virtual TargetWorkout TargetWorkout { get; set; }

        [Display(Name = "Time of Day")]
        public virtual TimeOfDay TimeOfDay { get; set; }
    }
}