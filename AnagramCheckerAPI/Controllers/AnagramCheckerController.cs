using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClassLibraryAnagram;

namespace AnagramCheckerAPI.Controllers {
    [ApiController]
    [Route("api")]
    public class AnagramCheckerController : ControllerBase {
        private readonly IDictionaryReader reader;
        private readonly ILogger<AnagramCheckerController> logger;
        public AnagramCheckerController(ILogger<AnagramCheckerController> logger, IDictionaryReader reader) {
            this.logger = logger;
            this.reader = reader;
        }

        [HttpGet]
        [Route("checkAnagram")]
        public IActionResult CheckIfAnagram([FromBody]PairOfWords words) {
            var checker = AnagramChecker.IsAnagram(words.w1, words.w2);
            if (checker) {
                return Ok("\"" + words.w1 + "\" and \"" + words.w2 + "\" are anagrams");
            } else {
                return BadRequest("\"" + words.w1 + "\" and " + words.w2 + " are no anagrams");
            }
            // return Ok("Words are Anagrams");

            // if pairofwords w1 == word-> return w2
        }

        [HttpGet]
        [Route("getKnownWords")]
        public IActionResult GetKnownWords([FromQuery]string word) {
            if (word == "" || word == null) {
                return NotFound("Please add a word the the query");
            }
            var anagramCheckerDictionary = new AnagramCheckerDictionary(reader);
            var knownWords = anagramCheckerDictionary.getKnown(word).Result;
            if (knownWords.Count() == 0) {
                logger.LogWarning("No Anagram found");
                return NotFound(word + " not Found");
            }
            string words = "";
            foreach(string kWord in knownWords) {
                if (kWord != word) {
                    words += kWord + ", ";
                }
            }
            return Ok("Known Anagrams: " + words);
            //return NotFound("");
        }
    }
}
