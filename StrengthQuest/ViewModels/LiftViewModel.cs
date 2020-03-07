using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels
{
    public class LiftViewModel
    {
        [Display(Name = "Max Lift")]
        public double MaxLift { get; set; }

        [Display(Name = "Training Max")]
        public double TrainingMaxLift { get; set; }

        [Display(Name = "Reps")]
        public int Reps { get; set; }

        [Display(Name = "Main Lift")]
        public bool IsMainLift { get; set; }

        [Display(Name = "Name")]
        public string LiftName { get; set; }

        [Display(Name = "Type")]
        public string LiftType { get; set; }

        public DateTime Date { get; set; }

        public string LiftId { get; set; }

        public double Set1 { get; set; }
        public double Set2 { get; set; }
        public double Set3 { get; set; }
        public double Set4 { get; set; }
        public double Set5 { get; set; }
        public double Set6 { get; set; }
        public double Set7 { get; set; }
        public double Set8 { get; set; }

    }
}
