using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryAnagram {
    public class AnagramChecker {
        public AnagramChecker() {//(String word1, String word2) {     // Credits: https://stackoverflow.com/questions/32778070/how-can-check-anagram-strings-in-c-sharp
    //       this.word1 = String.Concat(word1.ToLower().OrderBy(c => c));
    //       this.word2 = String.Concat(word2.ToLower().OrderBy(c => c));
        }

        public static Boolean IsAnagram(String word1, String word2) {
            word1 = String.Concat(word1.ToLower().OrderBy(c => c));
            word2 = String.Concat(word2.ToLower().OrderBy(c => c));
            return word1.Equals(word2);
        }

    }
}
