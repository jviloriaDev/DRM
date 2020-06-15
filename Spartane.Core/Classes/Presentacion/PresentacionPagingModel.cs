using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Presentacion
{
    public class PresentacionPagingModel
    {
        public List<Spartane.Core.Classes.Presentacion.Presentacion> Presentacions { set; get; }
        public int RowCount { set; get; }
    }
}
