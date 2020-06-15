using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllRespuesta_Logica : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Respuesta_Logica_Clave { get; set; }
        public string Respuesta_Logica_Descripcion { get; set; }

    }
}
