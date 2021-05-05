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
        public int Month { get; init; }

        public int Num { get; init; }

        public string Link { get; init; }

        public int Year { get; init; }

        public string News { get; init; }

        public string Safe_title { get; init; }

        public string Transcript { get; init; }

        public string Alt { get; init; }

        public string Img { get; init; }

        public string Title { get; init; }

        public int Day { get; init; }
    }
}