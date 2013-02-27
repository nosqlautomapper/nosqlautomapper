using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NoSqlAutomapper.Automapper;

namespace NoSqlAutomapper
{
    public static class AutomapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> Reduce<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression,
            Expression<Func<TDestination, dynamic>> reduce)
        {
            var customMappingExpression = expression as ICustomMappingExpression<TSource, TDestination> ??
                                          new CustomMappingExpression<TSource, TDestination>(expression);

            customMappingExpression.Data.Reduce = reduce;

            return customMappingExpression as IMappingExpression<TSource, TDestination>;
        }
    }
}
