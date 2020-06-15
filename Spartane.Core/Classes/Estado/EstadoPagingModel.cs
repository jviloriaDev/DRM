using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Estado
{
    public class EstadoPagingModel
    {
        public List<Spartane.Core.Classes.Estado.Estado> Estados { set; get; }
        public int RowCount { set; get; }
    }
}
