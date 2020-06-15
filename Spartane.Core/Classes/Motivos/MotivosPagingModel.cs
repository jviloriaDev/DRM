using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Motivos
{
    public class MotivosPagingModel
    {
        public List<Spartane.Core.Classes.Motivos.Motivos> Motivoss { set; get; }
        public int RowCount { set; get; }
    }
}
