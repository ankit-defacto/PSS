namespace ConcordMfg.PremierSeniorSolutions.WebService.DataAccess
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Predicate builder class
    /// <see cref="http://www.albahari.com/nutshell/predicatebuilder.aspx"/>
    /// </summary>
    public static class PredicateBuilder
    {
        /// <summary>
        /// Returns true predicate initializer
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <returns>Expression true</returns>
        public static Expression<Func<T, bool>> True<T>() { return f => true; }

        /// <summary>
        /// Returns false predicate initializer
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <returns>Expression false</returns>
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        /// <summary>
        /// Or builder
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="expr1">Left expression</param>
        /// <param name="expr2">Input expression</param>
        /// <returns>Expression</returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
                                                            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        /// <summary>
        /// And builder
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="expr1">Left expression</param>
        /// <param name="expr2">Input expression</param>
        /// <returns>Expression</returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
    }
}