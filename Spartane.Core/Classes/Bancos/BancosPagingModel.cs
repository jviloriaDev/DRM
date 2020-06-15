using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Bancos
{
    public class BancosPagingModel
    {
        public List<Spartane.Core.Classes.Bancos.Bancos> Bancoss { set; get; }
        public int RowCount { set; get; }
    }
}
