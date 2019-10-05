using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryAnagram {
    public class AnagramChecker {
        string word1;
        string word2;
        public AnagramChecker(String word1, String word2) {     // Credits: https://stackoverflow.com/questions/32778070/how-can-check-anagram-strings-in-c-sharp
            this.word1 = String.Concat(word1.OrderBy(c => c));
            this.word2 = String.Concat(word2.OrderBy(c => c));
        }

        public Boolean IsAnagram() {
            if (word1 == word2) {
                return true;
            }
            return false;
        }

    }
}
