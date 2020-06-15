using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllResultados_IMC : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Resultados_IMC_Folio { get; set; }
        public int Resultados_IMC_Folio_Pacientes { get; set; }
        public DateTime? Resultados_IMC_Fecha { get; set; }
        public int? Resultados_IMC_IMC { get; set; }
        public string Resultados_IMC_Estatus { get; set; }

    }
}
