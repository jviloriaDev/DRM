using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Empresas
{
    public class EmpresasPagingModel
    {
        public List<Spartane.Core.Classes.Empresas.Empresas> Empresass { set; get; }
        public int RowCount { set; get; }
    }
}
