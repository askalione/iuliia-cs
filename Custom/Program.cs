using Iuliia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Custom
{
    class Program
    {
        static void Main(string[] args)
        {
            var schemeSamples = new Dictionary<string, List<List<string>>>();
            var schemesProps = typeof(CustomSchemes).GetProperties();
            foreach (var schemeProp in schemesProps)
            {
                var scheme = schemeProp.GetValue(null, null) as Scheme;
                var samples = GetSamples(scheme);
                schemeSamples.Add(scheme.Name, samples);
            }

            var result = JsonSerializer.Serialize(schemeSamples, options: new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            var path = Path.Combine(Directory.GetCurrentDirectory(), "samples.json");

            File.WriteAllText(path, result);

            Console.WriteLine("Done!");
        }

        private static List<List<string>> GetSamples(Scheme scheme)
        {
            var samples = new List<List<string>>();

            samples.Add(new List<string> { "Юлия, съешь ещё этих мягких французских булок из Йошкар-Олы, да выпей алтайского чаю" });
            samples.Add(new List<string> { "Жуковец Анастасия" });
            samples.Add(new List<string> { "Радович Константин" });
            samples.Add(new List<string> { "Васильев Егор" });
            samples.Add(new List<string> { "Рейхтман Юрий" });

            foreach (var sample in samples)
            {
                sample.Add(IuliiaTranslator.Translate(sample[0], scheme));
            }

            return samples;
        }
    }
}
