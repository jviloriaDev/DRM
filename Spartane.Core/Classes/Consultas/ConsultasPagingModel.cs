using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Consultas
{
    public class ConsultasPagingModel
    {
        public List<Spartane.Core.Classes.Consultas.Consultas> Consultass { set; get; }
        public int RowCount { set; get; }
    }
}
