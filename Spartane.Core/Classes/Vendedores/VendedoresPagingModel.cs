using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Vendedores
{
    public class VendedoresPagingModel
    {
        public List<Spartane.Core.Classes.Vendedores.Vendedores> Vendedoress { set; get; }
        public int RowCount { set; get; }
    }
}
