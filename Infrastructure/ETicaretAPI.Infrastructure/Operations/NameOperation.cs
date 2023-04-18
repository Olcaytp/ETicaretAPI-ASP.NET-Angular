using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Operations
{
    internal class NameOperation
    {
        public static string CharacterRegulatory(string name)
        {
            string source = @"ığüşöçĞÜŞİÖÇâß\!'^+%&/()=?_@€¨~,;:<>|. ";
            string destination = @"igusocGUSIOC                          --";

            for (int i = 0; i < source.Length; i++)
            {
                name = name.Replace(source[i], destination[i]);
            }
            return name;
        }
        /*
        public static string CharacterRegulatory(string name)
            => name.Replace("\"", "")
                .Replace("!", "")
                .Replace("'", "")
                .Replace("^", "")
                .Replace("+", "")
                .Replace("%", "")
                .Replace("&", "")
                .Replace("/", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("=", "")
                .Replace("?", "")
                .Replace("_", "")
                .Replace(" ", "-")
                .Replace("@", "")
                .Replace("€", "")
                .Replace("¨", "")
                .Replace("~", "")
                .Replace(",", "")
                .Replace(";", "")
                .Replace(":", "")
                .Replace(".", "-")
                .Replace("Ö", "o")
                .Replace("ö", "o")
                .Replace("Ü", "u")
                .Replace("ü", "u")
                .Replace("ı", "i")
                .Replace("İ", "i")
                .Replace("ğ", "g")
                .Replace("Ğ", "g")
                .Replace("æ", "")
                .Replace("ß", "")
                .Replace("â", "a")
                .Replace("î", "i")
                .Replace("ş", "s")
                .Replace("Ş", "s")
                .Replace("Ç", "c")
                .Replace("ç", "c")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "");
        */
    }
}
