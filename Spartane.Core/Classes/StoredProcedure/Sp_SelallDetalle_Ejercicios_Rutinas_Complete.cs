using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Ejercicios_Rutinas_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Rutinas { get; set; }
        public int? Orden_de_realizacion { get; set; }
        public int? Numero_de_serie { get; set; }
        public int? Ejercicio { get; set; }
        public string Ejercicio_Nombre_del_Ejercicio { get; set; }
        public int? Cantidad_de_Repeticiones { get; set; }

    }
}
