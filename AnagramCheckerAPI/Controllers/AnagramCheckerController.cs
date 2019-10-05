using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnagramCheckerAPI.Controllers {
    [ApiController]
    [Route("api/checkAnagram")]
    public class AnagramCheckerController : ControllerBase {
        [HttpGet]
        public IActionResult GetAllContacts([FromBody]PairOfWords words) {
            var checker = new ClassLibraryAnagram.AnagramChecker(words.w1, words.w2);
            if (checker.IsAnagram()) {
                return Ok("\"" + words.w1 + "\" and \"" + words.w2 + "\" are anagrams");
            } else {
                return BadRequest("\"" + words.w1 + "\" and " + words.w2 + " are no anagrams");
            }
            // return Ok("Words are Anagrams");
        }
    }
}
