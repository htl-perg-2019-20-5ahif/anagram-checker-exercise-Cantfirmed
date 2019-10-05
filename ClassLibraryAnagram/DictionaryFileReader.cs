using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace ClassLibraryAnagram {
    public class DictionaryFileReader {
        private IConfiguration config;
        public DictionaryFileReader(IConfiguration config) {
            this.config = config;
        }
        /// <summary>
        /// Reads the dictionary file
        /// </summary>
        /// <returns>Dictionary text</returns>
        public async Task<string> ReadDictionary() {
            // Get DictionaryFileName from the config file
            var dictFile = config["DictionaryFileName"];
            // Read all Text async
            var dictionaryText = await File.ReadAllTextAsync(dictFile);
            return dictionaryText;
        }
    }
    
}
