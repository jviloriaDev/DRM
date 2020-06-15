using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Codigos_Referidos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Codigos_Referidos_Folio { get; set; }
        public int Detalle_Codigos_Referidos_Folio_Medicos { get; set; }
        public int? Detalle_Codigos_Referidos_Suscripcion { get; set; }
        public string Detalle_Codigos_Referidos_Suscripcion_Nombre_del_Plan { get; set; }
        public int? Detalle_Codigos_Referidos_Porcentaje_de_descuento { get; set; }
        public DateTime? Detalle_Codigos_Referidos_Fecha_inicio_vigencia { get; set; }
        public DateTime? Detalle_Codigos_Referidos_Fecha_fin_vigencia { get; set; }
        public int? Detalle_Codigos_Referidos_Cantidad_maxima_de_referenciados { get; set; }
        public string Detalle_Codigos_Referidos_Codigo_para_Referenciados { get; set; }
        public bool? Detalle_Codigos_Referidos_Autorizado { get; set; }
        public int? Detalle_Codigos_Referidos_Usuario_que_autoriza { get; set; }
        public string Detalle_Codigos_Referidos_Usuario_que_autoriza_Name { get; set; }
        public DateTime? Detalle_Codigos_Referidos_Fecha_de_autorizacion { get; set; }
        public string Detalle_Codigos_Referidos_Hora_de_autorizacion { get; set; }
        public int? Detalle_Codigos_Referidos_Estatus { get; set; }
        public string Detalle_Codigos_Referidos_Estatus_Descripcion { get; set; }

    }
}
