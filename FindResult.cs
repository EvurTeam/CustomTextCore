using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomTextCore
{
    public class FindResult
    {
        public int Start { set; get; }
        public int End { set; get; }
        public int Length { set; get; }
        public string Content { set; get; }

        public FindResult(Match match)
        {
            Content = match.Value;
            Start = match.Index;
            Length = Content.Length;
            End = match.Index + Content.Length;
        }

        public bool Contains(FindResult fr)
        {

        }

        public override string ToString()
        {
            return $"{{Start={Start}, End={End}, Length={Length} Content={Content}}}";
        }
    }
}
