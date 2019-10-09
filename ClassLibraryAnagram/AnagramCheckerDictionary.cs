using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryAnagram {
    public class AnagramCheckerDictionary {

        IDictionaryReader reader;
        //DictionaryFileReader dfr = new DictionaryFileReader(new IConfiguration);
        public AnagramCheckerDictionary(IDictionaryReader reader) {
            this.reader = reader;
        }

        public async Task<IEnumerable<string>> getKnown(string word) {  // Funktioniert nicht
            var listOfWords = await reader.ReadDictionary();
            var knownWords = new HashSet<string>();
            foreach (PairOfWords words in listOfWords) {
                if (words.w1 == word || AnagramChecker.IsAnagram(word, words.w1)) {
                    knownWords.Add(words.w2);
                }
                if (words.w2 == word || AnagramChecker.IsAnagram(word, words.w2)) {
                    knownWords.Add(words.w1);
                }
            }
            
            return knownWords;
        }
    }
}
