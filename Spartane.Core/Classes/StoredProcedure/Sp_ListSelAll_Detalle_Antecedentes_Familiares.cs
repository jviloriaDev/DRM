using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Antecedentes_Familiares : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Antecedentes_Familiares_Folio { get; set; }
        public int Detalle_Antecedentes_Familiares_Folio_Pacientes { get; set; }
        public int? Detalle_Antecedentes_Familiares_Enfermedad { get; set; }
        public string Detalle_Antecedentes_Familiares_Enfermedad_Descripcion { get; set; }
        public int? Detalle_Antecedentes_Familiares_Parentesco { get; set; }
        public string Detalle_Antecedentes_Familiares_Parentesco_Descripcion { get; set; }

    }
}
