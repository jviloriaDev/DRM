using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Aseguradoras
{
    public class AseguradorasPagingModel
    {
        public List<Spartane.Core.Classes.Aseguradoras.Aseguradoras> Aseguradorass { set; get; }
        public int RowCount { set; get; }
    }
}
