using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryAnagram {
    public interface IDictionaryReader {
        Task<List<PairOfWords>> ReadDictionary();
    }
}
