using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllRango_de_Horas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Rango_de_Horas_Clave { get; set; }
        public string Rango_de_Horas_Descripcion { get; set; }

    }
}
