using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace DluzynaSzkola2.Infrastructure
{
    public class HtmlUtility
    {
        private static readonly Regex HtmlTagExpression = new Regex(@"
          (?'tag_start'</?)
          (?'tag'\w+)((\s+
          (?'attribute'(\w+)(\s*=\s*(?:"".*?""|'.*?'|[^'"">\s]+)))?)+\s*|\s*)
          (?'tag_end'/?>)",
            RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static readonly Regex HtmlAttributeExpression = new Regex(@"
          (?'attribute'\w+)
          (\s*=\s*)
          (""(?'value'.*?)""|'(?'value'.*?)')",
            RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static readonly Dictionary<string, List<string>> ValidHtmlTags = new Dictionary<string, List<string>>
      {
          {"p", new List<string>          {"style", "class", "align"}},
          {"div", new List<string>        {"style", "class", "align"}},
          {"span", new List<string>       {"style", "class"}},
          {"br", new List<string>         {"style", "class"}},
          {"hr", new List<string>         {"style", "class"}},
          {"label", new List<string>      {"style", "class"}},

          {"h1", new List<string>         {"style", "class"}},
          {"h2", new List<string>         {"style", "class"}},
          {"h3", new List<string>         {"style", "class"}},
          {"h4", new List<string>         {"style", "class"}},
          {"h5", new List<string>         {"style", "class"}},
          {"h6", new List<string>         {"style", "class"}},

          {"font", new List<string>       {"style", "class", "color", "face", "size"}},
          {"strong", new List<string>     {"style", "class"}},
          {"b", new List<string>          {"style", "class"}},
          {"em", new List<string>         {"style", "class"}},
          {"i", new List<string>          {"style", "class"}},
          {"u", new List<string>          {"style", "class"}},
          {"strike", new List<string>     {"style", "class"}},
          {"ol", new List<string>         {"style", "class"}},
          {"ul", new List<string>         {"style", "class"}},
          {"li", new List<string>         {"style", "class"}},
          {"blockquote", new List<string> {"style", "class"}},
          {"code", new List<string>       {"style", "class"}},

          {"a", new List<string>          {"style", "class", "href", "title", "target"}},

          {"img", new List<string>        {"style", "class", "src", "height", "width", "alt", "title", "hspace", "vspace", "border"}},

          {"table", new List<string>      {"style", "class"}},
          {"thead", new List<string>      {"style", "class"}},
          {"tbody", new List<string>      {"style", "class"}},
          {"tfoot", new List<string>      {"style", "class"}},
          {"th", new List<string>         {"style", "class", "scope"}},
          {"tr", new List<string>         {"style", "class"}},
          {"td", new List<string>         {"style", "class", "colspan"}},

          {"q", new List<string>          {"style", "class", "cite"}},
          {"cite", new List<string>       {"style", "class"}},
          {"abbr", new List<string>       {"style", "class"}},
          {"acronym", new List<string>    {"style", "class"}},
          {"del", new List<string>        {"style", "class"}},
          {"ins", new List<string>        {"style", "class"}}
      };

        /// <summary>
        /// Encodes the invalid HTML tags.
        /// </summary>
        /// <param name="input">The text.</param>
        /// <returns></returns>
        public static string RemoveInvalidHtmlTags(string input)
        {
            var html = input;
            if (string.IsNullOrEmpty(html))
                return HttpUtility.HtmlEncode(input);

            return HtmlTagExpression.Replace(html, new MatchEvaluator(match =>
            {
                var builder = new StringBuilder(match.Length);

                var tagStart = match.Groups["tag_start"];
                var tagEnd = match.Groups["tag_end"];
                var tag = match.Groups["tag"].Value;
                var attributes = match.Groups["attribute"];

                if (false == ValidHtmlTags.ContainsKey(tag))
                {
                    builder.Append(tagStart.Success ? tagStart.Value : "<");
                    builder.Append(tag);
                    builder.Append(tagEnd.Success ? tagEnd.Value : ">");

                    return HttpUtility.HtmlEncode(builder.ToString());
                }

                builder.Append(tagStart.Success ? tagStart.Value : "<");
                builder.Append(tag);

                foreach (Capture attribute in attributes.Captures)
                {
                    builder.Append(MatchHtmlAttribute(tag, attribute));
                }

                // add nofollow to all hyperlinks
                if (tagStart.Success && tagStart.Value == "<" && tag.Equals("a", StringComparison.OrdinalIgnoreCase))
                    builder.Append(" rel=\"nofollow\"");

                builder.Append(tagEnd.Success ? tagEnd.Value : ">");

                return builder.ToString();
            }));
        }

        private static string MatchHtmlAttribute(string tag, Capture capture)
        {
            var output = string.Empty;
            var match = HtmlAttributeExpression.Match(capture.Value);

            var attribute = match.Groups["attribute"].Value;
            var value = match.Groups["value"].Value;

            if (ValidHtmlTags[tag].Contains(attribute))
            {
                switch (attribute)
                {
                    case "src":
                    case "href":
                        if (Regex.IsMatch(value, @"https?://[^""]+"))
                            //modified for external links
                            output = string.Format(" {0}=\"{1}\"", attribute, new Uri(value).ToString());
                        break;
                    default:
                        output = string.Format(" {0}=\"{1}\"", attribute, value);
                        break;
                }
            }
            return output;
        }
    }
}
