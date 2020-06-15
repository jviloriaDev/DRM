using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTipo_Paciente : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Tipo_Paciente_Clave { get; set; }
        public string Tipo_Paciente_Descripcion { get; set; }
        public int? Tipo_Paciente_Clave_Rol { get; set; }

    }
}
