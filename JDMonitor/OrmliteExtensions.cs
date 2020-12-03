using System;
using System.Data;
using System.Linq.Expressions;
using ServiceStack.OrmLite;

namespace JDMonitor
{
    public static class OrmliteExtensions
    {
        public static void CreateColumnIfNotExists<T>(this IDbConnection db, Expression<Func<T, object>> field)
        {
            if (!db.ColumnExists<T>(field)) db.AddColumn<T>(field);
        }
        public static SqlExpression<T> AndIf<T>(this SqlExpression<T> expr, bool where, string sqlFilter, params object[] filterParams)
        {
            if (where) return expr.And(sqlFilter, filterParams);
            return expr;
        }

    }
}
