using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_assignment
{
    internal abstract class Data_Exportor
    {
        public void Export(string outputpath)
        {
            ConnectToSource();
            var data = FetchData();
            var Formatted = FormatData(data);
            SaveToFile(outputpath, Formatted);

        }

        protected virtual void ConnectToSource()
        {
            Console.WriteLine("Connecting to data source...");
        }

        protected virtual List<Dictionary<string, object>> FetchData()
        {
            Console.WriteLine("Fetching data...");
            // Demo rows
            return new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { ["Id"] = 1, ["Name"] = "Deepti", ["Role"] = "Trainee" },
                new Dictionary<string, object> { ["Id"] = 2, ["Name"] = "Bidya",  ["Role"] = "Manager" }
            };
        }

        protected abstract string FormatData(List<Dictionary<string, object>> rows);

        protected virtual void SaveToFile(string path, string content)
        {
            Console.WriteLine($"Saving to file: {path}");
            File.WriteAllText(path, content);
            Console.WriteLine("Export complete.");
        }

    }

    internal sealed class CsvExporter : Data_Exportor
    {

        protected override string FormatData(List<Dictionary<string, object>> rows)
        {

            if (rows.Count == 0) return string.Empty;

            var headers = new List<string>(rows[0].Keys);
            var lines = new List<string> { string.Join(",", headers) };

            foreach (var row in rows)
            {
                var values = new List<string>();
                foreach (var h in headers)
                {
                    var v = row[h]?.ToString() ?? "";
                    // basic CSV escaping
                    if (v.Contains(",") || v.Contains("\""))
                        v = $"\"{v.Replace("\"", "\"\"")}\"";
                    values.Add(v);
                }
                lines.Add(string.Join(",", values));
            }
            return string.Join(Environment.NewLine, lines);

        }

    }

    internal sealed class JsonExporter : Data_Exportor
    {

        protected override string FormatData(List<Dictionary<string, object>> rows)
        {

            var objects = new List<string>();
            foreach (var row in rows)
            {
                var fields = new List<string>();
                foreach (var kv in row)
                {
                    var val = kv.Value?.ToString() ?? "";
                    val = val.Replace("\\", "\\\\").Replace("\"", "\\\"");
                    fields.Add($"\"{kv.Key}\": \"{val}\"");
                }
                objects.Add("{ " + string.Join(", ", fields) + " }");
            }
            return "[\n  " + string.Join(",\n  ", objects) + "\n]";

        }

    }

    internal sealed class XmlExporter : Data_Exportor
    {

        protected override string FormatData(List<Dictionary<string, object>> rows)
        {

            var lines = new List<string> { "<Rows>" };
            foreach (var row in rows)
            {
                lines.Add("  <Row>");
                foreach (var kv in row)
                {
                    var val = System.Security.SecurityElement.Escape(kv.Value?.ToString() ?? "");
                    lines.Add($"    <{kv.Key}>{val}</{kv.Key}>");
                }
                lines.Add("  </Row>");
            }
            lines.Add("</Rows>");
            return string.Join(Environment.NewLine, lines);

        }

    }
    internal class Data_Exportor_Template
    {
        static void Main(string[] args)
        {

            Data_Exportor exporter;

            exporter = new CsvExporter();
            exporter.Export("data.csv");
            Console.WriteLine("==================");

            exporter = new JsonExporter();
            exporter.Export("data.json");
            Console.WriteLine("==================");

            exporter = new XmlExporter();
            exporter.Export("data.xml");

        }
    }


}