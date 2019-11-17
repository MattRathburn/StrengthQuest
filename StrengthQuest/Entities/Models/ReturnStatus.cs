using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
  public class ReturnStatus
  {
    public string Message { get; set; }
    public string StackTrace { get; set; }
    public bool IsSuccessful { get; set; }
    public string Url { get; set; }
  }
}
