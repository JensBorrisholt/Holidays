using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HolidayGrapper.Helpers;
using HtmlAgilityPack;

namespace HolidayGrapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClipBoardMonitor.NewUrl += Addtask;
        }

        private void GenerateDelphiFile(KnownHolidays knownHolidays, List<HolidayRow> holidayList,
            HtmlAgilityPack.HtmlDocument htmlDocument, string country)
        {
            var filename = $@"C:\Users\Jens\source\repos\Holidays\Demo\CalendricalCalculations\NationalHolidays\{country}U.pas";
            if (File.Exists(filename))
                return;
            var lines = new List<string>
            {
                $"unit {country}U;",
                "",
                "interface",
                "",
                "uses",
                "  BaseNationalHolidaysU;",
                "",
                "type",
                $"  {country} = class sealed(TBaseNationalHolidays)",
                "  public",
                "    function MakeHolydays: TBaseNationalHolidays; override;",
                "    function SundayName: string; override;",
                "  end;",
                "",
                "implementation",
                "",
                "{ "+ country +" }",
                "",
                $"function {country}.MakeHolydays: TBaseNationalHolidays;",
                "begin"
            };

            foreach (var element in holidayList)
            {
                var knownHoliday = knownHolidays.FirstOrDefault(e => e.Date == element.Date);

                if (knownHoliday != null)
                    lines.Add($"  Add({knownHoliday.EnglishName}, '{element.Name.Replace("'", "''") }');");
                else
                {
                    var s = "TMonth." + Enum.GetName(typeof(KnownHolidays.Month), element.Date.Month);
                    lines.Add($"  Add(Year, {s}, {element.Date.Day}, '{element.Name.Replace("'", "''")}');");
                }
            }

            lines.AddRange(
                new[]{
                    "end;",
                    "",
                    $"function {country}.SundayName: string;",
                    "begin",
                    "  Result := 'Sunday';",
                    "end;"
                });

            lines.Add("");

            var ulNode = htmlDocument.DocumentNode.Descendants("ul").Where(e => e.HasAttributes).FirstOrDefault(e => e.Attributes.First().Value == "circle_list");
            if (ulNode != null)
            {

                lines.Add("(*");
                lines.Add("  Notes");

                foreach (var element in ulNode.Descendants("li"))
                    lines.Add("    * " + element.InnerText.Trim());
                lines.Add("*)");
            }

            lines.Add("end.");

            File.WriteAllLines(filename, lines);
            lines.Clear();

            foreach (var element in holidayList.Where(e => !string.IsNullOrEmpty(e.Comment)))
                lines.Add(element.Name + "\t\t\t\t" + element.Comment);

            textBox1.Text = string.Join(Environment.NewLine, lines);
        }

        private void GenerateCSharpFile(KnownHolidays knownHolidays, List<HolidayRow> holidayList, HtmlAgilityPack.HtmlDocument htmlDocument, string country)
        {
            var filename = $"C:\\Users\\Jens\\source\\repos\\HolidayTest\\CalendricalCalculations\\NationalHolidays\\{country}.cs";
            if (File.Exists(filename))
                return;

            var lines = new List<string>
            {
                "namespace CalendricalCalculation.NationalHolidays",
                "{",
                $"    public class {country} : BaseNationalHolidays",
                "    {",
                "        public override string SundayName { get; } = \"Sunday\";",
                "        public override BaseNationalHolidays MakeHolydays()",
                "        {"
            };


            foreach (var element in holidayList)
            {
                var knownHoliday = knownHolidays.FirstOrDefault(e => e.Date == element.Date);

                if (knownHoliday != null)
                    lines.Add($"            Add({knownHoliday.EnglishName}, \"{element.Name}\");");
                else
                {
                    var s = "Month." + Enum.GetName(typeof(KnownHolidays.Month), element.Date.Month);
                    lines.Add($"            Add(Year, {s}, {element.Date.Day}, \"{element.Name}\");");
                }
            }


            lines.Add("            return this;");
            lines.Add("        }");
            lines.Add("    }");
            lines.Add("}");

            lines.Add("");

            var ulNode = htmlDocument.DocumentNode.Descendants("ul").Where(e => e.HasAttributes).FirstOrDefault(e => e.Attributes.First().Value == "circle_list");
            if (ulNode != null)
            {

                lines.Add("/*");
                lines.Add("  Notes");

                foreach (var element in ulNode.Descendants("li"))
                    lines.Add("    * " + element.InnerText.Trim());
                lines.Add("*/");
            }

            File.WriteAllLines(filename, lines);
            lines.Clear();

            foreach (var element in holidayList.Where(e => !string.IsNullOrEmpty(e.Comment)))
                lines.Add(element.Name + "\t\t\t\t" + element.Comment);

            textBox1.Text = string.Join(Environment.NewLine, lines);
        }
        private void Addtask(string url)
        {
            url = url.Replace("index.php", "2019");
            var result = UrlValidator.IsValidUrl(url, out var country, out var year);
            if (!result && url.EndsWith("/")) //try harder
            {
                url += "2019";
                result = UrlValidator.IsValidUrl(url, out country, out year);
            }

            if (!result)
                return;

            url = url.ToLower();
            var htmlDocument = new HtmlWeb().Load(url);
            var tableSource = htmlDocument.DocumentNode.Descendants("Table")
                .FirstOrDefault(e => e.Attributes["class"].Value == "list-table");
            var tableBody = tableSource?.Descendants("tbody").FirstOrDefault();
            if (tableBody == null)
                return;

            var holidayList = new List<HolidayRow>();
            foreach (var row in tableBody.Descendants("tr").Where(e => e.Attributes["class"].Value == "holiday"))
                holidayList.Add(new HolidayRow(row));

            var knownHolidays = KnownHolidays.GetList(year, holidayList.Exists(e => e.Name.Contains("Orthodox")));

            holidayList.Sort((x, y) => x.Date.CompareTo(y.Date));

            GenerateCSharpFile(knownHolidays, holidayList, htmlDocument, country);
            GenerateDelphiFile(knownHolidays, holidayList, htmlDocument, country);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
