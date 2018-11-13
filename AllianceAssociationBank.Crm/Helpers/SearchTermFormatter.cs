
using System.Linq;
using System.Text.RegularExpressions;

namespace AllianceAssociationBank.Crm.Helpers
{
    public class SearchTermFormatter
    {
        private const string WILDCARD = @"%";

        public string SearchTerm { get; }

        public SearchTermFormatter(string searchTerm)
        {
            SearchTerm = TrimString(searchTerm);
        }

        public string FormatForExactMatch()
        {
            return SearchTerm;
        }

        public string FormatForTIN()
        {
            var value = SearchTerm;

            var regex1 = new Regex(@"^\d{2}-\d{7}");
            var regex2 = new Regex(@"^\d{9}");

            if (regex1.IsMatch(value))
            {
                return SearchTerm.Replace("-", WILDCARD);
            }
            else if (regex2.IsMatch(value))
            {
                return value.Substring(0, 2) + WILDCARD + value.Substring(2);
            }

            return value;
        }

        public string FormatForPhone()
        {
            var value = SearchTerm;

            var regex = new Regex(@".*\d{3}.*\d{3}.*\d{4}");

            if (regex.IsMatch(value))
            {
                var phoneNumeric = new string(value.Where(c => char.IsDigit(c)).ToArray());

                return WILDCARD + phoneNumeric.Substring(0, 3) + WILDCARD +
                       phoneNumeric.Substring(3, 3) + WILDCARD +
                       phoneNumeric.Substring(6, 4) + WILDCARD +
                       (phoneNumeric.Length > 10 ? phoneNumeric.Substring(10) : "");
            }

            return value;
        }

        public string FormatForName()
        {
            var value = SearchTerm;

            return WILDCARD + value.Replace(" ", WILDCARD) + WILDCARD;
        }

        private string TrimString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return value.Trim();
        }
    }
}