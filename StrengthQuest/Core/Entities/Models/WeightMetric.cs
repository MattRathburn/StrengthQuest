using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class WeightMetric
    {
        public string Id { get; set; }

        public bool IsPound { get; set; }

        [Required]
        public string UserId { get; set; }

    }
}
