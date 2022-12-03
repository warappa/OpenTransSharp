using System;
using System.Linq.Expressions;
using System.Reflection;

namespace BMEcatSharp.Internal
{
    internal static class ExpressionExtensions
    {
        public static string GetPropertyName<TObject>(this Expression<Func<TObject, object?>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var propertyInfo = PropertyInfoInternal(expression);

            return propertyInfo.Name;
        }
        private static PropertyInfo PropertyInfoInternal(this LambdaExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var body = expression.Body as MemberExpression ?? (expression.Body as UnaryExpression)?.Operand as MemberExpression;
            var propertyInfo = body?.Member as PropertyInfo;

            if (propertyInfo == null)
            {
                throw new ArgumentException("The given expression does not contain a property.");
            }

            return propertyInfo;
        }
    }
}
