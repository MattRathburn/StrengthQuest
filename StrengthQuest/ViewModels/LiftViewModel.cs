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

        public bool IsMainLift { get; set; }

        [Display(Name = "Name")]
        public string LiftName { get; set; }

        [Display(Name = "Type")]
        public string LiftType { get; set; }

        public int LiftSequence { get; set; }

        public DateTime Date { get; set; }

        public Lift Lift { get; set; }
    }
}
