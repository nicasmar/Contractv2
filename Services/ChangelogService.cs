using Contractv2.Helpers;

namespace Contractv2.Services
{
    public class ChangelogService
    {
        private diff_match_patch _diffHelper;
        public ChangelogService()
        {
            _diffHelper = new diff_match_patch();
        }

        public void GetHtmlDifference(string html1Path, string html2Path, string htmlChangelogPath)
        {
            string html1Prefix, html1Sufix, html2Prefix, html2Sufix;
            html1Prefix = html1Sufix = html2Prefix = html2Sufix = string.Empty;

            SplitHtml(ref html1Path, ref html1Prefix, ref html1Sufix, ref html2Path, ref html2Prefix, ref html2Sufix);

            List<Diff> result = _diffHelper.diff_main(html1Sufix, html2Sufix, false);
            _diffHelper.diff_cleanupSemantic(result);

            using (StreamWriter sw = new StreamWriter(htmlChangelogPath))
            {
                sw.Write(html2Prefix);
                sw.Write("</style></head><body>");
                foreach (Diff item in result)
                {
                    switch (item.operation)
                    {
                        case Operation.DELETE:
                            sw.Write("<span style=\"color:red\"><s>" + item.text + "</s></span>");
                            break;
                        case Operation.INSERT:
                            sw.Write("<span style=\"color:green\">" + item.text + "</span>");
                            break;
                        case Operation.EQUAL:
                            sw.Write(item.text);
                            break;
                        default:
                            break;
                    }
                }
            }

            return;
        }

        private void SplitHtml(ref string html1Path, ref string html1Prefix, ref string html1Sufix, ref string html2Path, ref string html2Prefix, ref string html2Sufix)
        {
            using (StreamReader sr = new StreamReader(html1Path))
            {
                // Read the file line by line
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    // Check if the line contains the "<body>" sequence
                    if (line.Contains("<body>"))
                    {
                        html1Sufix = line.Substring(line.IndexOf("<body>") + 6) + Environment.NewLine;
                        while (!sr.EndOfStream)
                        {
                            html1Sufix += sr.ReadLine() + Environment.NewLine;
                        }
                        break;
                    }
                    else
                    {
                        html1Prefix += line + Environment.NewLine;
                    }
                }
            }

            using (StreamReader sr = new StreamReader(html2Path))
            {
                // Read the file line by line
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    // Check if the line contains the "<body>" sequence
                    if (line.Contains("<body>"))
                    {
                        html2Sufix = line.Substring(line.IndexOf("<body>") + 6) + Environment.NewLine;
                        while (!sr.EndOfStream)
                        {
                            html2Sufix += sr.ReadLine() + Environment.NewLine;
                        }
                        break;
                    }
                    else
                    {
                        html2Prefix += line + Environment.NewLine;
                    }
                }
            }
        }
    }
}