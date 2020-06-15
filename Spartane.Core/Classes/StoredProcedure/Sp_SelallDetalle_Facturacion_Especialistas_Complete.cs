using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Facturacion_Especialistas_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Especialistas { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Folio_Factura { get; set; }
        public string Periodo_Facturado { get; set; }
        public decimal? Cantidad { get; set; }
        public int? Archivo_XML { get; set; }
        public int? Archivo_PDF { get; set; }
        public int? Estatus { get; set; }
        public DateTime? Fecha_programada_de_Pago { get; set; }
        public bool? Pagada { get; set; }
        public DateTime? Fecha_de_pago { get; set; }

    }
}
