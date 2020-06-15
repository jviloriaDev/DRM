using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Tipo_Paciente
{
    public class Tipo_PacientePagingModel
    {
        public List<Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente> Tipo_Pacientes { set; get; }
        public int RowCount { set; get; }
    }
}
