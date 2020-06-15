using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Facturacion_Vendedores : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Facturacion_Vendedores_Folio { get; set; }
        public DateTime? Detalle_Facturacion_Vendedores_Fecha_de_Registro { get; set; }
        public string Detalle_Facturacion_Vendedores_Folio_Factura { get; set; }
        public string Detalle_Facturacion_Vendedores_Periodo_Facturado { get; set; }
        public decimal? Detalle_Facturacion_Vendedores_Cantidad { get; set; }
        public int? Detalle_Facturacion_Vendedores_Archivo_XML { get; set; }
        public string Detalle_Facturacion_Vendedores_Archivo_XML_Nombre { get; set; }
        public int? Detalle_Facturacion_Vendedores_Archivo_PDF { get; set; }
        public string Detalle_Facturacion_Vendedores_Archivo_PDF_Nombre { get; set; }
        public int? Detalle_Facturacion_Vendedores_Estatus { get; set; }
        public string Detalle_Facturacion_Vendedores_Estatus_Descripcion { get; set; }
        public DateTime? Detalle_Facturacion_Vendedores_Fecha_programada_de_Pago { get; set; }
        public bool? Detalle_Facturacion_Vendedores_Pagada { get; set; }
        public DateTime? Detalle_Facturacion_Vendedores_Fecha_de_Pago { get; set; }

    }
}
