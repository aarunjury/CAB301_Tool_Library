using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Assignment

{
    /// <summary>
    /// This class when called, creates a new TablePrinter object which displays the data in
    /// an aesthetically pleasing way.
    /// Adapted from StackOverflow user Sumudu <https://stackoverflow.com/a/54943087/11969856>
    /// </summary>
    public class TablePrinter
    {
        private readonly string[] titles;
        private readonly List<int> lengths;
        private readonly List<string[]> rows = new List<string[]>();

        //TablePrinter object takes the header row as strings
        public TablePrinter(params string[] titles)
        {
            this.titles = titles;
            lengths = titles.Select(t => t.Length).ToList();
        }

        //This method is called when creating the object to add the actual rows of data
        //underneath the title row
        public void AddRow(params object[] row)
        {
            if (row.Length != titles.Length)
            {
                throw new System.Exception($"Added row length [{row.Length}] is not equal to title row length [{titles.Length}]");
            }
            rows.Add(row.Select(o => o.ToString()).ToArray());
            for (int i = 0; i < titles.Length; i++)
            {
                if (rows.Last()[i].Length > lengths[i])
                {
                    lengths[i] = rows.Last()[i].Length;
                }
            }
        }

        //Using WriteLine, once the title row and data rows are supplied, the data can now
        //actually be printed to the screen
        public void Print()
        {
            lengths.ForEach(l => Write("+-" + new string('-', l) + '-'));
            WriteLine("+");

            string line = "";
            for (int i = 0; i < titles.Length; i++)
            {
                line += "| " + titles[i].PadRight(lengths[i]) + ' ';
            }
            WriteLine(line + "|");

            lengths.ForEach(l => Write("+-" + new string('-', l) + '-'));
            WriteLine("+");

            foreach (var row in rows)
            {
                line = "";
                for (int i = 0; i < row.Length; i++)
                {
                    if (int.TryParse(row[i], out int n))
                    {
                        line += "| " + row[i].PadLeft(lengths[i]) + ' ';  //numbers are padded to the left
                    }
                    else
                    {
                        line += "| " + row[i].PadRight(lengths[i]) + ' ';
                    }
                }
                WriteLine(line + "|");
            }

            lengths.ForEach(l => Write("+-" + new string('-', l) + '-'));
            WriteLine("+");
        }
    }
}