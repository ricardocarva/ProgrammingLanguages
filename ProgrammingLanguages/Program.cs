using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ProgrammingLanguages
{
    class Program
    {
        static void Main()
        {

            /*
            In this project I use lists and LINQ to search a database for answers!

            The data is stored in a .tsv file, which stands for tab-separated values. 
            It’s a common way to export data from a spreadsheet or database — you might see this file type when you try to
            download data from apps like Microsoft Excel and Google Sheets.

            If you would like to create a tsv file from a txt file, do the following:

                Open any folder window.
                Press Alt+T+O (that’s the letter O, not a zero) to open the Folder Options dialog box.
                Click the View tab.
                Remove the tick (checkmark) beside ‘Hide extensions for known file types’ and click OK.

                      Author: Ricardo Carvalheira
          */
            List<Language> languages = File.ReadAllLines("./languages.tsv")
              .Skip(1)
              .Select(line => Language.FromTsv(line))
              .ToList();

            //Returns a string for each language. It should include the year, name, and chief developer of each language.
            var stringLang = languages.Select(l => $"{l.Year} {l.Name} {l.ChiefDeveloper}");

            //Find the language(s) with the name "C#". Use the Prettify() method to print the results to the console.

            var cSharpList = languages.Where(l => l.Name == "C#");

            //Find all of the languages which have "Microsoft" included in their ChiefDeveloper property.
            var microsoftList = languages.Where(l => l.ChiefDeveloper.Contains("Microsoft"));

            //Find all of the languages that descend from Lisp.
            var lispDescend = languages.Where(l => l.Predecessors.Contains("Lisp"));

            //Find all of the language names that contain the word "Script" (capital S). Make sure the query only selects the name of each language
            var scriptLangs = languages.Where(l => l.Name.Contains("Script")).Select(l => l.Name);

            //Queries many languages were launched between 1995 and 2005
            //var nearMilleniumLangs = languages.Where(l=> l.Year>=1995 && l.Year<=2005);

            //Queries many languages were launched between 1995 and 2005 and formats de result like this: NAME was invented in YEAR

            var nearMilleniumLangs = languages.Where(l => l.Year >= 1995 && l.Year <= 2005).Select(l => $"{l.Name} was invented in {l.Year}");

            //PrettyPrintAll(lispDescend);
            //PrintAll(nearMilleniumLangs);

            //Sort alphabetically
            var ordered = languages.OrderBy(x => x.Name);

            //Find the oldest language in the list 
            //Find the year first
            var oldestYear = languages.Min(x => x.Year);
            //Then find the languages that contain that year
            var oldestLanguages = languages.Where(l => l.Year == oldestYear);

            PrettyPrintAll(oldestLanguages);

            Console.WriteLine("\r\n     Press Enter to close tab...");
            Console.ReadLine();
            Console.Clear();
        }

        //Prints languages
        public static void PrettyPrintAll(IEnumerable<Language> langs)
        {
            foreach (Language lang in langs)
            {
                Console.WriteLine(lang.Prettify());
            }

        }

        //Prints objects/strings
        public static void PrintAll(IEnumerable<Object> sequence)
        {
            foreach (Object obj in sequence)
            {
                Console.WriteLine(obj);
            }

        }
    }
}
