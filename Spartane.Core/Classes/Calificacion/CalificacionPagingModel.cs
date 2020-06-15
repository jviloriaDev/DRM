using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Calificacion
{
    public class CalificacionPagingModel
    {
        public List<Spartane.Core.Classes.Calificacion.Calificacion> Calificacions { set; get; }
        public int RowCount { set; get; }
    }
}
