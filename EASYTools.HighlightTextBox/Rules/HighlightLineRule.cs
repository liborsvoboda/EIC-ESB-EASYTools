using System.Xml.Linq;

namespace EASYTools.HighlightTextBox
{
    public class HighlightLineRule : Rule
    {
        public HighlightLineRule(XElement rule)
        {
            LineStart = rule.Element("LineStart")?.Value.Trim();
            Options = new RuleOptions(rule);
        }

        public string LineStart { get; }
    }
}