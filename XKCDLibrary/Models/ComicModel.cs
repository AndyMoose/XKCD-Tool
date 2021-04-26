using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XKCDLibrary.Models
{
    public record Comic
    {
        public int Month { get; set; }

        public int Num { get; set; }

        public string Link { get; set; }

        public int Year { get; set; }

        public string News { get; set; }

        public string Safe_title { get; set; }

        public string Transcript { get; set; }

        public string Alt { get; set; }

        public string Img { get; set; }

        public string Title { get; set; }

        public int Day { get; set; }
    }
}