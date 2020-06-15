using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Codigos_de_Referencia_Vendedores_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int FolioVendedores { get; set; }
        public int? Porcentaje_de_descuento { get; set; }
        public DateTime? Fecha_inicio_vigencia { get; set; }
        public DateTime? Fecha_fin_vigencia { get; set; }
        public int? Cantidad_maxima_de_referenciados { get; set; }
        public string Codigo_para_referenciados { get; set; }
        public bool? Autorizado { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public string Usuario_que_autoriza_Name { get; set; }
        public DateTime? Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
