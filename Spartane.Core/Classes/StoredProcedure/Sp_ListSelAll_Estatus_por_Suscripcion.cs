using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEstatus_por_Suscripcion : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Estatus_por_Suscripcion_Clave { get; set; }
        public string Estatus_por_Suscripcion_Descripcion { get; set; }

    }
}
