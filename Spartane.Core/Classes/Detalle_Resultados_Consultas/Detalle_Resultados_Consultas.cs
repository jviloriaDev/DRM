using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Consultas;
using Spartane.Core.Classes.Pacientes;
using Spartane.Core.Classes.Indicadores_Consultas;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Resultados_Consultas
{
    /// <summary>
    /// Detalle_Resultados_Consultas table
    /// </summary>
    public class Detalle_Resultados_Consultas: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Consultas { get; set; }
        public int? Folio_Pacientes { get; set; }
        public DateTime? Fecha_de_Consulta { get; set; }
        public int? Indicador { get; set; }
        public int? Resultado { get; set; }
        public string Interpretacion { get; set; }
        public int? IMC { get; set; }
        public int? IMC_Pediatria { get; set; }

        [ForeignKey("Folio_Consultas")]
        public virtual Spartane.Core.Classes.Consultas.Consultas Folio_Consultas_Consultas { get; set; }
        [ForeignKey("Folio_Pacientes")]
        public virtual Spartane.Core.Classes.Pacientes.Pacientes Folio_Pacientes_Pacientes { get; set; }
        [ForeignKey("Indicador")]
        public virtual Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas Indicador_Indicadores_Consultas { get; set; }

    }
}

