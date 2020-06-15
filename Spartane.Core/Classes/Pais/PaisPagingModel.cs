using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Pais
{
    public class PaisPagingModel
    {
        public List<Spartane.Core.Classes.Pais.Pais> Paiss { set; get; }
        public int RowCount { set; get; }
    }
}
