using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllPlanes_de_Suscripcion : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Planes_de_Suscripcion_Folio { get; set; }
        public DateTime? Planes_de_Suscripcion_Fecha_de_Registro { get; set; }
        public string Planes_de_Suscripcion_Hora_de_Registro { get; set; }
        public int? Planes_de_Suscripcion_Usuario_que_Registra { get; set; }
        public string Planes_de_Suscripcion_Usuario_que_Registra_Name { get; set; }
        public int? Planes_de_Suscripcion_Tipo_de_Beneficiario { get; set; }
        public string Planes_de_Suscripcion_Tipo_de_Beneficiario_Nombre { get; set; }
        public string Planes_de_Suscripcion_Nombre { get; set; }
        public string Planes_de_Suscripcion_Nombre_del_Plan { get; set; }
        public int? Planes_de_Suscripcion_Duracion_en_meses { get; set; }
        public int? Planes_de_Suscripcion_Duracion { get; set; }
        public int? Planes_de_Suscripcion_Dietas_por_mes { get; set; }
        public int? Planes_de_Suscripcion_Rutinas_por_mes { get; set; }
        public decimal? Planes_de_Suscripcion_Costo_mensual { get; set; }
        public decimal? Planes_de_Suscripcion_Precio_Final { get; set; }
        public int? Planes_de_Suscripcion_Estatus { get; set; }
        public string Planes_de_Suscripcion_Estatus_Descripcion { get; set; }

    }
}
