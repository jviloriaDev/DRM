using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Detalle_Pagos_Paciente
{
    public class Detalle_Pagos_PacientePagingModel
    {
        public List<Spartane.Core.Classes.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente> Detalle_Pagos_Pacientes { set; get; }
        public int RowCount { set; get; }
    }
}
