using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Facturacion_Especialistas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Facturacion_Especialistas_Folio { get; set; }
        public int Detalle_Facturacion_Especialistas_Folio_Especialistas { get; set; }
        public DateTime? Detalle_Facturacion_Especialistas_Fecha_de_Registro { get; set; }
        public string Detalle_Facturacion_Especialistas_Folio_Factura { get; set; }
        public string Detalle_Facturacion_Especialistas_Periodo_Facturado { get; set; }
        public decimal? Detalle_Facturacion_Especialistas_Cantidad { get; set; }
        public int? Detalle_Facturacion_Especialistas_Archivo_XML { get; set; }
        public string Detalle_Facturacion_Especialistas_Archivo_XML_Nombre { get; set; }
        public int? Detalle_Facturacion_Especialistas_Archivo_PDF { get; set; }
        public string Detalle_Facturacion_Especialistas_Archivo_PDF_Nombre { get; set; }
        public int? Detalle_Facturacion_Especialistas_Estatus { get; set; }
        public DateTime? Detalle_Facturacion_Especialistas_Fecha_programada_de_Pago { get; set; }
        public bool? Detalle_Facturacion_Especialistas_Pagada { get; set; }
        public DateTime? Detalle_Facturacion_Especialistas_Fecha_de_pago { get; set; }

    }
}
