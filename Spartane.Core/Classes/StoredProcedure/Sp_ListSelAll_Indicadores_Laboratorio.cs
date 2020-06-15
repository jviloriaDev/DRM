using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllIndicadores_Laboratorio : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Indicadores_Laboratorio_Folio { get; set; }
        public string Indicadores_Laboratorio_Indicador { get; set; }
        public string Indicadores_Laboratorio_Unidad_de_Medida { get; set; }
        public int? Indicadores_Laboratorio_Limite_inferior { get; set; }
        public int? Indicadores_Laboratorio_Limite_superior { get; set; }

    }
}
