﻿using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Platillos
{
    public class PlatillosPagingModel
    {
        public List<Spartane.Core.Classes.Platillos.Platillos> Platilloss { set; get; }
        public int RowCount { set; get; }
    }
}
