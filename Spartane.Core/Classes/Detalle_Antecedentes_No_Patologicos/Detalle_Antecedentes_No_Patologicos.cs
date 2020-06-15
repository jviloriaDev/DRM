using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Pacientes;
using Spartane.Core.Classes.Sustancias;
using Spartane.Core.Classes.Frecuencia_Sustancias;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Antecedentes_No_Patologicos
{
    /// <summary>
    /// Detalle_Antecedentes_No_Patologicos table
    /// </summary>
    public class Detalle_Antecedentes_No_Patologicos: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public int? Sustancia { get; set; }
        public int? Frecuencia { get; set; }
        public int? Cantidad { get; set; }

        [ForeignKey("Folio_Pacientes")]
        public virtual Spartane.Core.Classes.Pacientes.Pacientes Folio_Pacientes_Pacientes { get; set; }
        [ForeignKey("Sustancia")]
        public virtual Spartane.Core.Classes.Sustancias.Sustancias Sustancia_Sustancias { get; set; }
        [ForeignKey("Frecuencia")]
        public virtual Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias Frecuencia_Frecuencia_Sustancias { get; set; }

    }
}

