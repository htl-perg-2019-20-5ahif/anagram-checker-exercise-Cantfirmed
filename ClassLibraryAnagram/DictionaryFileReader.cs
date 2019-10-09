using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ClassLibraryAnagram {
    public class DictionaryFileReader : IDictionaryReader {
        private IConfiguration config;
        public DictionaryFileReader(IConfiguration config) {
            this.config = config;
        }
        /// <summary>
        /// Reads the dictionary file
        /// </summary>
        /// <returns>Dictionary text</returns>
        public async Task<List<PairOfWords>> ReadDictionary() {
            // Get DictionaryFileName from the config file
            var dictFile = config["DictionaryFileName"];
            // Read all Text async
            var json = await File.ReadAllTextAsync(dictFile);
            return JsonConvert.DeserializeObject<List<PairOfWords>>(json);
        }


    }

}
