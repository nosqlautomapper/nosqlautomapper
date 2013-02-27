using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlAutomapper.Automapper
{
    public class CustomMapingExpressionData<TSource, TDestination>
    {
        public Expression<Func<TDestination, dynamic>> Reduce { get; set; }
    }
}
