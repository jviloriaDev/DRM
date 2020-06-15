using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Empresas;
using Spartane.Core.Classes.Planes_de_Suscripcion;
using Spartane.Core.Classes.Tipos_de_Contrato;
using Spartane.Core.Classes.Spartane_File;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Contratos_Empresa
{
    /// <summary>
    /// Detalle_Contratos_Empresa table
    /// </summary>
    public class Detalle_Contratos_Empresa: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Empresas { get; set; }
        public int? Suscripcion { get; set; }
        public int? Tipo_de_Contrato { get; set; }
        public int? Documento { get; set; }
        //public string Documento_URL { get; set; }
        public DateTime? Fecha_de_Firma_de_Contrato { get; set; }

        [ForeignKey("Folio_Empresas")]
        public virtual Spartane.Core.Classes.Empresas.Empresas Folio_Empresas_Empresas { get; set; }
        [ForeignKey("Suscripcion")]
        public virtual Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion Suscripcion_Planes_de_Suscripcion { get; set; }
        [ForeignKey("Tipo_de_Contrato")]
        public virtual Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato Tipo_de_Contrato_Tipos_de_Contrato { get; set; }
        [ForeignKey("Documento")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Documento_Spartane_File { get; set; }

    }
}

