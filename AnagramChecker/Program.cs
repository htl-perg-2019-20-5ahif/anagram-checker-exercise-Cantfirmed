using ClassLibraryAnagram;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramChecker {
    class Program {
        static void Main(string[] args) {
            if (args[0] == "check" && args[1] != null && args[2] != null) {
                checkIfAnagram(args);
            }
            if (args[0] == "getKnown" && args[1] != null) {
                getKnownAnagrams(args);
            }
        }

        private static void getKnownAnagrams(string[] args) {
            DictionaryFileReader reader = new DictionaryFileReader(GetConfiguration().Build());
            if (args[1] == "" || args[1] == null) {
                Console.WriteLine("Please add a word the the query");
            }
            var anagramCheckerDictionary = new AnagramCheckerDictionary(reader);
            var knownWords = anagramCheckerDictionary.getKnown(args[1]).Result.ToList();
            if (knownWords.Count == 0) {
                Console.WriteLine(args[1] + " not Found");
            }
            string words = "";
            foreach (string kWord in knownWords) {
                if (kWord != args[1]) {
                    words += kWord + ", ";
                }
            }
            Console.WriteLine("Known Anagrams: " + words);
        }

        private static void checkIfAnagram(string[] args) {
            var checker = ClassLibraryAnagram.AnagramChecker.IsAnagram(args[1], args[2]);
            if (checker) {
                Console.WriteLine("\"" + args[1] + "\" and \"" + args[2] + "\" are anagrams");
            } else {
                Console.WriteLine("\"" + args[1] + "\" and \"" + args[2] + "\" are no anagrams");
            }
        }

        private static IConfigurationBuilder GetConfiguration() {
            var environmentName = Environment.GetEnvironmentVariable("Hosting:Environment");
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();
        }
    }
}
