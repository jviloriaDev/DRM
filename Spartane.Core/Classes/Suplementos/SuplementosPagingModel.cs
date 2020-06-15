using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Suplementos
{
    public class SuplementosPagingModel
    {
        public List<Spartane.Core.Classes.Suplementos.Suplementos> Suplementoss { set; get; }
        public int RowCount { set; get; }
    }
}
