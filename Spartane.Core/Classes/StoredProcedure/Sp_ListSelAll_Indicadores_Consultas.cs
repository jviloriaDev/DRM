using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllIndicadores_Consultas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Indicadores_Consultas_Clave { get; set; }
        public string Indicadores_Consultas_Nombre { get; set; }

    }
}
