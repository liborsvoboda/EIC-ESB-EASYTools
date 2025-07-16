using System.Xml.Linq;

namespace EASYTools.HighlightTextBox
{
    public class AdvancedHighlightRule : Rule
    {
        public AdvancedHighlightRule(XElement rule)
        {
            Expression = rule.Element("Expression")?.Value.Trim();
            Options = new RuleOptions(rule);
        }

        public string Expression { get; }
    }
}