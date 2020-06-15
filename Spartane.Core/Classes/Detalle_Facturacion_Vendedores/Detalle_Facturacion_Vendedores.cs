using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Vendedores;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Estatus_Facturas;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Facturacion_Vendedores
{
    /// <summary>
    /// Detalle_Facturacion_Vendedores table
    /// </summary>
    public class Detalle_Facturacion_Vendedores: BaseEntity
    {
        public int Folio { get; set; }
        public int? FolioVendedores { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Folio_Factura { get; set; }
        public string Periodo_Facturado { get; set; }
        public decimal? Cantidad { get; set; }
        public int? Archivo_XML { get; set; }
        //public string Archivo_XML_URL { get; set; }
        public int? Archivo_PDF { get; set; }
        //public string Archivo_PDF_URL { get; set; }
        public int? Estatus { get; set; }
        public DateTime? Fecha_programada_de_Pago { get; set; }
        public bool? Pagada { get; set; }
        public DateTime? Fecha_de_Pago { get; set; }

        [ForeignKey("FolioVendedores")]
        public virtual Spartane.Core.Classes.Vendedores.Vendedores FolioVendedores_Vendedores { get; set; }
        [ForeignKey("Archivo_XML")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Archivo_XML_Spartane_File { get; set; }
        [ForeignKey("Archivo_PDF")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Archivo_PDF_Spartane_File { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus_Facturas.Estatus_Facturas Estatus_Estatus_Facturas { get; set; }

    }
}

