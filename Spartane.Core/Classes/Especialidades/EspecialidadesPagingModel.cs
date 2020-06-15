using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Especialidades
{
    public class EspecialidadesPagingModel
    {
        public List<Spartane.Core.Classes.Especialidades.Especialidades> Especialidadess { set; get; }
        public int RowCount { set; get; }
    }
}
