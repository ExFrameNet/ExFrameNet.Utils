using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ExFrameNet.Utils.System
{
    public static class ExpressionExtensions
    {
        public static string GetPropertyName<T, TProperty>(this Expression<Func<T, TProperty>> expression)
        {
			var propInfo = expression.GetMember();
            return propInfo.Name;
        }

        public static PropertyInfo GetPropertyInfo<T, TProperty>(this Expression<Func<T, TProperty>> expression)
        {
            var member = expression.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException($"Expression refers to a method");

            var propInfo = member.Member as PropertyInfo;

            if (propInfo == null)
                throw new ArgumentException("Expression refers to a field");

            return propInfo;
        }

		public static MemberInfo? GetMember<T, TProperty>(this Expression<Func<T, TProperty>> expression)
		{
			var memberExp = RemoveUnary(expression.Body) as MemberExpression;

			if (memberExp == null)
			{
				return null;
			}

			Expression currentExpr = memberExp.Expression;

			// Unwind the expression to get the root object that the expression acts upon.
			while (true)
			{
				currentExpr = RemoveUnary(currentExpr);

				if (currentExpr != null && currentExpr.NodeType == ExpressionType.MemberAccess)
				{
					currentExpr = ((MemberExpression)currentExpr).Expression;
				}
				else
				{
					break;
				}
			}

			if (currentExpr == null || currentExpr.NodeType != ExpressionType.Parameter)
			{
				return null; // We don't care if we're not acting upon the model instance.
			}

			return memberExp.Member;
		}

		private static Expression RemoveUnary(Expression toUnwrap)
		{
			if (toUnwrap is UnaryExpression)
			{
				return ((UnaryExpression)toUnwrap).Operand;
			}

			return toUnwrap;
		}
	}
}

