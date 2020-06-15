using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Antecedentes_No_Patologicos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Antecedentes_No_Patologicos_Folio { get; set; }
        public int Detalle_Antecedentes_No_Patologicos_Folio_Pacientes { get; set; }
        public int? Detalle_Antecedentes_No_Patologicos_Sustancia { get; set; }
        public string Detalle_Antecedentes_No_Patologicos_Sustancia_Descripcion { get; set; }
        public int? Detalle_Antecedentes_No_Patologicos_Frecuencia { get; set; }
        public string Detalle_Antecedentes_No_Patologicos_Frecuencia_Descripcion { get; set; }
        public int? Detalle_Antecedentes_No_Patologicos_Cantidad { get; set; }

    }
}
