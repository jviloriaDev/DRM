using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTipo_de_Plan_de_Suscripcion : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Tipo_de_Plan_de_Suscripcion_Clave { get; set; }
        public string Tipo_de_Plan_de_Suscripcion_Nombre { get; set; }

    }
}
