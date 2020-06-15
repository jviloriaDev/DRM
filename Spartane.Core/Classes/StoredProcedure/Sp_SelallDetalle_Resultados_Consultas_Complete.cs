using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Resultados_Consultas_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Consultas { get; set; }
        public int? Folio_Pacientes { get; set; }
        public string Folio_Pacientes_Nombre_Completo { get; set; }
        public DateTime? Fecha_de_Consulta { get; set; }
        public int? Indicador { get; set; }
        public string Indicador_Nombre { get; set; }
        public int? Resultado { get; set; }
        public string Interpretacion { get; set; }
        public int? IMC { get; set; }
        public int? IMC_Pediatria { get; set; }

    }
}
