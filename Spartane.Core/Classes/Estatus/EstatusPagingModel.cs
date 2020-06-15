using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Estatus
{
    public class EstatusPagingModel
    {
        public List<Spartane.Core.Classes.Estatus.Estatus> Estatuss { set; get; }
        public int RowCount { set; get; }
    }
}
