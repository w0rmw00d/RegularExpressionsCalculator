using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegularExpressionsCalculator.Models
{
    public class OverlayViewModel
    {
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public List<Tuple<string,string>> Links { get; set; }
    }
}