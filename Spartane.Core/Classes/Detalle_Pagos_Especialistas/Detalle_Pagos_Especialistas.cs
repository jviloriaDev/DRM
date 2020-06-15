using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Medicos;
using Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas;
using Spartane.Core.Classes.Formas_de_Pago;
using Spartane.Core.Classes.Estatus_de_Pago;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Pagos_Especialistas
{
    /// <summary>
    /// Detalle_Pagos_Especialistas table
    /// </summary>
    public class Detalle_Pagos_Especialistas: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Especialistas { get; set; }
        public int? Plan_de_Suscripcion { get; set; }
        public string Concepto_de_Pago { get; set; }
        public DateTime? Fecha_Limite_de_Pago { get; set; }
        public int? Recordatorio_dias { get; set; }
        public int? Forma_de_Pago { get; set; }
        public DateTime? Fecha_de_Pago { get; set; }
        public int? Estatus { get; set; }
        public DateTime? Fecha_de_Suscripcion { get; set; }
        public int? Numero_de_Pago { get; set; }
        public int? De_Total_de_Pagos { get; set; }

        [ForeignKey("Folio_Especialistas")]
        public virtual Spartane.Core.Classes.Medicos.Medicos Folio_Especialistas_Medicos { get; set; }
        [ForeignKey("Plan_de_Suscripcion")]
        public virtual Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas Plan_de_Suscripcion_Planes_de_Suscripcion_Especialistas { get; set; }
        [ForeignKey("Forma_de_Pago")]
        public virtual Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago Forma_de_Pago_Formas_de_Pago { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus_de_Pago.Estatus_de_Pago Estatus_Estatus_de_Pago { get; set; }

    }
}

