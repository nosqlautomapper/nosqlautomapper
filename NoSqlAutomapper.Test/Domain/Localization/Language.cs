﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlAutomapper.Test.Domain.Localization
{
    public class Language: EntityBase
    {
        public String Title { get; set; }

        public String Code { get; set; }
    }
}
