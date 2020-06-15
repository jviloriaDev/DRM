using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Pacientes;
using Spartane.Core.Classes.Padecimientos;
using Spartane.Core.Classes.Tiempo_Padecimiento;
using Spartane.Core.Classes.Respuesta_Logica;
using Spartane.Core.Classes.Estatus_Padecimiento;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_de_Padecimientos
{
    /// <summary>
    /// Detalle_de_Padecimientos table
    /// </summary>
    public class Detalle_de_Padecimientos: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public int? Padecimiento { get; set; }
        public int? Tiempo_con_el_diagnostico { get; set; }
        public int? Intervencion_quirurgica { get; set; }
        public string Tratamiento { get; set; }
        public int? Estado_actual { get; set; }

        [ForeignKey("Folio_Pacientes")]
        public virtual Spartane.Core.Classes.Pacientes.Pacientes Folio_Pacientes_Pacientes { get; set; }
        [ForeignKey("Padecimiento")]
        public virtual Spartane.Core.Classes.Padecimientos.Padecimientos Padecimiento_Padecimientos { get; set; }
        [ForeignKey("Tiempo_con_el_diagnostico")]
        public virtual Spartane.Core.Classes.Tiempo_Padecimiento.Tiempo_Padecimiento Tiempo_con_el_diagnostico_Tiempo_Padecimiento { get; set; }
        [ForeignKey("Intervencion_quirurgica")]
        public virtual Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica Intervencion_quirurgica_Respuesta_Logica { get; set; }
        [ForeignKey("Estado_actual")]
        public virtual Spartane.Core.Classes.Estatus_Padecimiento.Estatus_Padecimiento Estado_actual_Estatus_Padecimiento { get; set; }

    }
}

