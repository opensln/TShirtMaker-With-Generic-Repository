using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTShirtStore.Models
{
    public enum Size
    {
        [Display(Name = "X Small")]
        XSmall,
        Small,
        Medium,
        Large,
        [Display(Name = "X Large")]
        XLarge
    }
    public class TShirt
    {
        public int ID { get; set; }
        public Size Size { get; set; }
        public string Color { get; set; }

        [Display(Name="Tight Fit?")]
        public bool isTightFit { get; set; }

        [Display(Name = "Message")]
        public string message { get; set; }
    }
}
