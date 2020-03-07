using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Lift
    {
        [Key]
        public string Id { get; set; }

        public double MaxLift { get; set; }

        public int Reps { get; set; }

        public bool IsMainLift { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual LiftName LiftName { get; set; }

        public virtual LiftType LiftType { get; set; }

    }
}
