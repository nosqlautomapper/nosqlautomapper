using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlAutomapper.Exceptions
{
    public class InitializationException: Exception
    {
        public InitializationException(String message) : base(message)
        {
            
        }
    }
}
