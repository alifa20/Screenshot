using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    public class FileNameFromURL
    {
        public string ConvertToWindowsFileName(string urlText)
        {
            List<string> urlParts = new List<string>();
            string rt = "";
            Regex r = new Regex(@"[a-z]+", RegexOptions.IgnoreCase);
            foreach (Match m in r.Matches(urlText))
            {
                urlParts.Add(m.Value);
            }
            for (int i = 0; i < urlParts.Count; i++)
            {
                rt = rt + urlParts[i];
                rt = rt + "_";
            }
            return rt;
        }
    }
}
