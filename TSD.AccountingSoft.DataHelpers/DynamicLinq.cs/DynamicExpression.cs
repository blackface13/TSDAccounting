using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TSD.AccountingSoft.DataHelpers.DynamicLinq.cs
{
    /// <summary>
    /// 
    /// </summary>
    public static class DynamicExpression
    {
        /// <summary>
        /// Parses the specified result type.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public static Expression Parse(Type resultType, string expression, params object[] values)
        {
            var parser = new ExpressionParser(null, expression, values);
            return parser.Parse(resultType);
        }

        /// <summary>
        /// Parses the lambda.
        /// </summary>
        /// <param name="itType">It type.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public static LambdaExpression ParseLambda(Type itType, Type resultType, string expression, params object[] values)
        {
            return ParseLambda(new[] { Expression.Parameter(itType, "") }, resultType, expression, values);
        }

        /// <summary>
        /// Parses the lambda.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public static LambdaExpression ParseLambda(ParameterExpression[] parameters, Type resultType, string expression, params object[] values)
        {
            var parser = new ExpressionParser(parameters, expression, values);
            return Expression.Lambda(parser.Parse(resultType), parameters);
        }

        /// <summary>
        /// Parses the lambda.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public static Expression<Func<T, TS>> ParseLambda<T, TS>(string expression, params object[] values)
        {
            return (Expression<Func<T, TS>>)ParseLambda(typeof(T), typeof(TS), expression, values);
        }

        /// <summary>
        /// Creates the class.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        public static Type CreateClass(params DynamicProperty[] properties)
        {
            return ClassFactory.Instance.GetDynamicClass(properties);
        }

        /// <summary>
        /// Creates the class.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        public static Type CreateClass(IEnumerable<DynamicProperty> properties)
        {
            return ClassFactory.Instance.GetDynamicClass(properties);
        }
    }
}
