using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Objetivos
{
    public class ObjetivosPagingModel
    {
        public List<Spartane.Core.Classes.Objetivos.Objetivos> Objetivoss { set; get; }
        public int RowCount { set; get; }
    }
}
