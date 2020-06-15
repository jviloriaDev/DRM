using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Medicos
{
    public class MedicosPagingModel
    {
        public List<Spartane.Core.Classes.Medicos.Medicos> Medicoss { set; get; }
        public int RowCount { set; get; }
    }
}
