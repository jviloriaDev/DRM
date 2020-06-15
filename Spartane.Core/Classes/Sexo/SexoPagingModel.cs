using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Sexo
{
    public class SexoPagingModel
    {
        public List<Spartane.Core.Classes.Sexo.Sexo> Sexos { set; get; }
        public int RowCount { set; get; }
    }
}
