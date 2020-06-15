using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSeleccion_de_Rangos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Seleccion_de_Rangos_Clave { get; set; }
        public string Seleccion_de_Rangos_Descripcion { get; set; }

    }
}
