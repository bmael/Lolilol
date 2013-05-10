namespace Tools.Linq.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// The delegate conversion visitor.
    /// </summary>
    public sealed class DelegateConversionVisitor : ExpressionVisitor
    {
        /// <summary>
        /// The parameters map.
        /// </summary>
        private readonly IDictionary<ParameterExpression, ParameterExpression> parametersMap;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateConversionVisitor"/> class.
        /// </summary>
        /// <param name="parametersMap">
        /// The parameters map.
        /// </param>
        public DelegateConversionVisitor(IDictionary<ParameterExpression, ParameterExpression> parametersMap)
        {
            this.parametersMap = parametersMap;
        }

        /// <summary>
        /// Convert an expression that take an interface (T1) in its parameters to one that take an implementation (T2) of this interface.
        /// </summary>
        /// <param name="expr">
        /// The expression to convert.
        /// </param>
        /// <typeparam name="T1">
        /// The source interface.
        /// </typeparam>
        /// <typeparam name="T2">
        /// The destination type, must implement T1.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The return type of the expression.
        /// </typeparam>
        /// <returns>
        /// The converted expression.
        /// </returns>
        public static Expression<Func<T2, TResult>> Convert<T1, T2, TResult>(Expression<Func<T1, TResult>> expr)
        {
            var parametersMap = expr.Parameters
                .Where(pe => pe.Type == typeof(T1))
                .ToDictionary(pe => pe, pe => Expression.Parameter(typeof(T2)));

            var visitor = new DelegateConversionVisitor(parametersMap);
            var newBody = visitor.Visit(expr.Body);

            var parameters = expr.Parameters.Select(visitor.MapParameter);

            return Expression.Lambda<Func<T2, TResult>>(newBody, parameters);
        }

        /// <summary>
        /// The visit parameter.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        /// <returns>
        /// The System.Linq.Expressions.Expression.
        /// </returns>
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return base.VisitParameter(this.MapParameter(node));
        }

        /// <summary>
        /// The map parameter.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <returns>
        /// The System.Linq.Expressions.ParameterExpression.
        /// </returns>
        private ParameterExpression MapParameter(ParameterExpression source)
        {
            ParameterExpression target;
            this.parametersMap.TryGetValue(source, out target);

            return target;
        }
    }
}