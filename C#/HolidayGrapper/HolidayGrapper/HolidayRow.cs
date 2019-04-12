using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace HolidayGrapper
{
    public class HolidayRow
    {
        private static readonly string MonhNames = "January|February|March|April|May|June|July|August|September|October|November|December";
        private static readonly string RegString = @"\b(January|February|March|April|May|June|July|August|September|October|November|December)\s+(\d{2})*";
        private static readonly Regex DateExpression = new Regex(RegString, RegexOptions.Compiled);
        private static readonly List<string> MonthList = MonhNames.Split('|').ToList();
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public HolidayRow(HtmlNode node)
        {
            var nodes = node.Descendants("td").ToList();
            var time = nodes[1].Descendants("time").FirstOrDefault()?.Attributes["datetime"];

            if (time != null)
                Date = DateTime.Parse(time.Value);
            else
            {
                var test = nodes[1].InnerText;
                var match = DateExpression.Matches(test)[0];

                if (match.Groups.Count == 3)
                    Date = new DateTime(2019, MonthList.IndexOf(match.Groups[1].Value) + 1, int.Parse(match.Groups[2].Value));
            }

            Name = nodes[2].InnerText.Replace("\n", "").Trim();
            Comment = nodes[3].InnerText.Replace("\n", "").Trim();
        }
    }
}