using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllPlanes_de_Suscripcion_Proveedores : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Planes_de_Suscripcion_Proveedores_Clave { get; set; }
        public string Planes_de_Suscripcion_Proveedores_Descripcion { get; set; }

    }
}
