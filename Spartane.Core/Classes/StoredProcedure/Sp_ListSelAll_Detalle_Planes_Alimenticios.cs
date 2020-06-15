using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Planes_Alimenticios : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Planes_Alimenticios_Folio { get; set; }
        public int Detalle_Planes_Alimenticios_Folio_Planes_Alimenticios { get; set; }
        public int? Detalle_Planes_Alimenticios_Tiempo_de_Comida { get; set; }
        public string Detalle_Planes_Alimenticios_Tiempo_de_Comida_Comida { get; set; }
        public int? Detalle_Planes_Alimenticios_Numero_de_Dia { get; set; }
        public string Detalle_Planes_Alimenticios_Numero_de_Dia_Dia { get; set; }
        public DateTime? Detalle_Planes_Alimenticios_Fecha { get; set; }
        public int? Detalle_Planes_Alimenticios_Platillo { get; set; }
        public string Detalle_Planes_Alimenticios_Platillo_Nombre_de_Platillo { get; set; }
        public bool? Detalle_Planes_Alimenticios_Modificado { get; set; }

    }
}
