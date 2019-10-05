using System;


namespace AnagramChecker {
    class Program {
        static void Main(string[] args) {
            if(args[0] == "check" && args[1] != null && args[2] != null) {
                var checker = new ClassLibraryAnagram.AnagramChecker(args[1], args[2]);
                if (checker.IsAnagram()) {
                    Console.WriteLine("\"" + args[1] + "\" and \"" + args[2] + "\" are anagrams");
                } else {
                    Console.WriteLine("\"" + args[1] + "\" and " + args[2] + " are no anagrams");
                }
            }
            
        }
    }
}
