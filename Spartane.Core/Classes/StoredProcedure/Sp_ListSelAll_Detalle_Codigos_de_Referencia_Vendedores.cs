using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Codigos_de_Referencia_Vendedores : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Codigos_de_Referencia_Vendedores_Folio { get; set; }
        public int Detalle_Codigos_de_Referencia_Vendedores_FolioVendedores { get; set; }
        public int? Detalle_Codigos_de_Referencia_Vendedores_Porcentaje_de_descuento { get; set; }
        public DateTime? Detalle_Codigos_de_Referencia_Vendedores_Fecha_inicio_vigencia { get; set; }
        public DateTime? Detalle_Codigos_de_Referencia_Vendedores_Fecha_fin_vigencia { get; set; }
        public int? Detalle_Codigos_de_Referencia_Vendedores_Cantidad_maxima_de_referenciados { get; set; }
        public string Detalle_Codigos_de_Referencia_Vendedores_Codigo_para_referenciados { get; set; }
        public bool? Detalle_Codigos_de_Referencia_Vendedores_Autorizado { get; set; }
        public int? Detalle_Codigos_de_Referencia_Vendedores_Usuario_que_autoriza { get; set; }
        public string Detalle_Codigos_de_Referencia_Vendedores_Usuario_que_autoriza_Name { get; set; }
        public DateTime? Detalle_Codigos_de_Referencia_Vendedores_Fecha_de_autorizacion { get; set; }
        public string Detalle_Codigos_de_Referencia_Vendedores_Hora_de_autorizacion { get; set; }
        public int? Detalle_Codigos_de_Referencia_Vendedores_Estatus { get; set; }
        public string Detalle_Codigos_de_Referencia_Vendedores_Estatus_Descripcion { get; set; }

    }
}
