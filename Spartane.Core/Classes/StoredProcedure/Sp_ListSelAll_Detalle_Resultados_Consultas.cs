using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Resultados_Consultas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Resultados_Consultas_Folio { get; set; }
        public int Detalle_Resultados_Consultas_Folio_Consultas { get; set; }
        public int? Detalle_Resultados_Consultas_Folio_Pacientes { get; set; }
        public string Detalle_Resultados_Consultas_Folio_Pacientes_Nombre_Completo { get; set; }
        public DateTime? Detalle_Resultados_Consultas_Fecha_de_Consulta { get; set; }
        public int? Detalle_Resultados_Consultas_Indicador { get; set; }
        public string Detalle_Resultados_Consultas_Indicador_Nombre { get; set; }
        public int? Detalle_Resultados_Consultas_Resultado { get; set; }
        public string Detalle_Resultados_Consultas_Interpretacion { get; set; }
        public int? Detalle_Resultados_Consultas_IMC { get; set; }
        public int? Detalle_Resultados_Consultas_IMC_Pediatria { get; set; }

    }
}
