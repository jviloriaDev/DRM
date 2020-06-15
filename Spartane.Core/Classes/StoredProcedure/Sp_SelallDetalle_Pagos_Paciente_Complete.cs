using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Pagos_Paciente_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Pacientes { get; set; }
        public int? Suscripcion { get; set; }
        public string Suscripcion_Nombre_del_Plan { get; set; }
        public string Concepto_de_Pago { get; set; }
        public DateTime? Fecha_de_Suscripcion { get; set; }
        public int? Numero_de_Pago { get; set; }
        public int? De_Total_de_Pagos { get; set; }
        public DateTime? Fecha_Limite_de_Pago { get; set; }
        public int? Recordatorio_dias { get; set; }
        public int? Forma_de_Pago { get; set; }
        public string Forma_de_Pago_Nombre { get; set; }
        public DateTime? Fecha_de_Pago { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
