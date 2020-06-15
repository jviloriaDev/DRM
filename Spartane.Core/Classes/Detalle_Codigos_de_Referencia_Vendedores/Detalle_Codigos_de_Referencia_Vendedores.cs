using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Vendedores;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Estatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Codigos_de_Referencia_Vendedores
{
    /// <summary>
    /// Detalle_Codigos_de_Referencia_Vendedores table
    /// </summary>
    public class Detalle_Codigos_de_Referencia_Vendedores: BaseEntity
    {
        public int Folio { get; set; }
        public int? FolioVendedores { get; set; }
        public int? Porcentaje_de_descuento { get; set; }
        public DateTime? Fecha_inicio_vigencia { get; set; }
        public DateTime? Fecha_fin_vigencia { get; set; }
        public int? Cantidad_maxima_de_referenciados { get; set; }
        public string Codigo_para_referenciados { get; set; }
        public bool? Autorizado { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public DateTime? Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("FolioVendedores")]
        public virtual Spartane.Core.Classes.Vendedores.Vendedores FolioVendedores_Vendedores { get; set; }
        [ForeignKey("Usuario_que_autoriza")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_que_autoriza_Spartan_User { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus.Estatus Estatus_Estatus { get; set; }

    }
}

