using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiPlatformOS
{
    public static class LinuxFileDialogHelper
    {
        public static string BuildLinuxFilterFromFilter(string filter) 
        {
            var parts = filter.Split('|');
            return BuildCaseInsensitiveFilter(parts[0].Trim(), parts[1]);
        }

        public static string BuildCaseInsensitiveFilter(string description, string extensionsList)
        {
            // Divide as extensões pelo ;
            var extensions = extensionsList.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            var allPatterns = new List<string>();
            foreach (var ext in extensions)
            {
                // Remove espaços e garante prefixo "*."
                string clean = ext.Trim();
                if (!clean.StartsWith("*")) { clean = "*." + clean.TrimStart('.'); }

                allPatterns.AddRange(GenerateCaseVariations(clean));
            }

            // Remove duplicados
            var finalPatterns = allPatterns.Distinct().ToArray();

            // Monta filtro no formato WinForms
            return $"{description}|{string.Join(";", finalPatterns)}";
        }

        private static IEnumerable<string> GenerateCaseVariations(string pattern)
        {
            var chars = pattern.ToCharArray();
            int combinations = 1 << chars.Count(c => char.IsLetter(c));

            for (int i = 0; i < combinations; i++)
            {
                var sb = new StringBuilder();
                int bit = 0;
                foreach (char c in chars)
                {
                    if (char.IsLetter(c))
                    {
                        sb.Append(((i >> bit) & 1) == 1 ? char.ToUpper(c) : char.ToLower(c));
                        bit++;
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                yield return sb.ToString();
            }
        }

    }
}
