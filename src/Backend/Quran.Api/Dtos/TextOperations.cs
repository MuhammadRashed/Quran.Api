using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quran.Api.Dtos
{
    public static class TextOperations
    {
      
        public static string SkipChars(string source)
        {
            char[] skip = new char[] { 'َ', 'ِ', 'ُ', 'ْ', 'ٓ' };
            char[] letters = new char[] { 'ٰ', 'ّ' };
            Tuple<char, char>[] replaceLetters = new Tuple<char, char>[] { new Tuple<char, char>('ٱ', 'ا') };

            var skipString = skip.Select(y => y.ToString()).ToArray();
            var skiplettersString = letters.Select(y => y.ToString()).ToArray();
            var result = source
                .Replace(skipString[0], "", StringComparison.OrdinalIgnoreCase)
                .Replace(skipString[1], "", StringComparison.OrdinalIgnoreCase)
                .Replace(skipString[2], "", StringComparison.OrdinalIgnoreCase)
                .Replace(skipString[3], "", StringComparison.OrdinalIgnoreCase)

                .Replace(skiplettersString[0], "", StringComparison.OrdinalIgnoreCase)
                .Replace(skiplettersString[1], "", StringComparison.OrdinalIgnoreCase)
                .Replace(replaceLetters[0].Item1.ToString(), replaceLetters[0].Item2.ToString(), StringComparison.OrdinalIgnoreCase)
                ;
            return result;
        }
    }
}
