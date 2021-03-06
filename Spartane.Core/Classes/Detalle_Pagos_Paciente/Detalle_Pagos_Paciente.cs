﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Pacientes;
using Spartane.Core.Classes.Planes_de_Suscripcion;
using Spartane.Core.Classes.Formas_de_Pago;
using Spartane.Core.Classes.Estatus_de_Pago;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Pagos_Paciente
{
    /// <summary>
    /// Detalle_Pagos_Paciente table
    /// </summary>
    public class Detalle_Pagos_Paciente: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public int? Suscripcion { get; set; }
        public string Concepto_de_Pago { get; set; }
        public DateTime? Fecha_de_Suscripcion { get; set; }
        public int? Numero_de_Pago { get; set; }
        public int? De_Total_de_Pagos { get; set; }
        public DateTime? Fecha_Limite_de_Pago { get; set; }
        public int? Recordatorio_dias { get; set; }
        public int? Forma_de_Pago { get; set; }
        public DateTime? Fecha_de_Pago { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Folio_Pacientes")]
        public virtual Spartane.Core.Classes.Pacientes.Pacientes Folio_Pacientes_Pacientes { get; set; }
        [ForeignKey("Suscripcion")]
        public virtual Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion Suscripcion_Planes_de_Suscripcion { get; set; }
        [ForeignKey("Forma_de_Pago")]
        public virtual Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago Forma_de_Pago_Formas_de_Pago { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus_de_Pago.Estatus_de_Pago Estatus_Estatus_de_Pago { get; set; }

    }
}

