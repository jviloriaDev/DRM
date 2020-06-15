using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Ejercicios_Rutinas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Ejercicios_Rutinas_Folio { get; set; }
        public int Detalle_Ejercicios_Rutinas_Folio_Rutinas { get; set; }
        public int? Detalle_Ejercicios_Rutinas_Orden_de_realizacion { get; set; }
        public int? Detalle_Ejercicios_Rutinas_Numero_de_serie { get; set; }
        public int? Detalle_Ejercicios_Rutinas_Ejercicio { get; set; }
        public string Detalle_Ejercicios_Rutinas_Ejercicio_Nombre_del_Ejercicio { get; set; }
        public int? Detalle_Ejercicios_Rutinas_Cantidad_de_Repeticiones { get; set; }

    }
}
