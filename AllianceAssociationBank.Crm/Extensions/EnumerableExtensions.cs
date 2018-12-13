using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AllianceAssociationBank.Crm.Extensions
{
    public static class EnumerableExtensions
    {
        public static string JoinStringProperty<T>(this IEnumerable<T> source, Expression<Func<T, string>> expression, string separator) where T : class
        {
            if (source == null)
            {
                return null;
            }

            var values = source
                .Select(expression.Compile())
                .Where(v => !string.IsNullOrEmpty(v));

            return string.Join(separator, values);
        }
    }
}