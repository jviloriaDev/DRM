using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDuracion_de_Planes_de_Suscripcion : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Duracion_de_Planes_de_Suscripcion_Clave { get; set; }
        public string Duracion_de_Planes_de_Suscripcion_Nombre { get; set; }
        public int? Duracion_de_Planes_de_Suscripcion_Cantidad_en_Meses { get; set; }
        public int? Duracion_de_Planes_de_Suscripcion_Cantidad_en_Dias { get; set; }

    }
}
