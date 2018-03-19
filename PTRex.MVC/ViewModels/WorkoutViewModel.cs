using PTRex.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTRex.MVC.ViewModels
{
    public class WorkoutViewModel
    {
        public WorkoutViewModel()
        {
            ActualWorkout = new ActualWorkout();
            TargetWorkout = new TargetWorkout();
        }

        public int SelectedTargetWorkoutId { get; set; }

        public ActualWorkout ActualWorkout { get; set; }

        public TargetWorkout TargetWorkout { get; set; }

    }
}