using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Pacientes;
using Spartane.Core.Classes.Indicadores_Laboratorio;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Examenes_Laboratorio
{
    /// <summary>
    /// Detalle_Examenes_Laboratorio table
    /// </summary>
    public class Detalle_Examenes_Laboratorio: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public int? Indicador { get; set; }
        public int? Resultado { get; set; }
        public string Unidad { get; set; }
        public string Intervalo_de_Referencia { get; set; }
        public DateTime? Fecha_de_Resultado { get; set; }
        public string Estatus_Indicador { get; set; }

        [ForeignKey("Folio_Pacientes")]
        public virtual Spartane.Core.Classes.Pacientes.Pacientes Folio_Pacientes_Pacientes { get; set; }
        [ForeignKey("Indicador")]
        public virtual Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio Indicador_Indicadores_Laboratorio { get; set; }

    }
}

