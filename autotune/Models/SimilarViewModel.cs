using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autotune.Models
{
    public class SimilarViewModel
    {
        public int FirstProductId { get; set; }
        List<Product> products { get; set; }
        public int LeftCount { get; set; }
        public int RightCount { get; set; }

        public SimilarViewModel()
        {
            LeftCount = 0;
            RightCount = 0;
        }
    }
}