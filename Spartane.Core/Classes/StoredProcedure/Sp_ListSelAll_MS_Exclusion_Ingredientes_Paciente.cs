using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_Exclusion_Ingredientes_Paciente : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_Exclusion_Ingredientes_Paciente_Folio { get; set; }
        public int MS_Exclusion_Ingredientes_Paciente_Folio_Pacientes { get; set; }
        public int? MS_Exclusion_Ingredientes_Paciente_Ingrediente { get; set; }
        public string MS_Exclusion_Ingredientes_Paciente_Ingrediente_Nombre_Ingrediente { get; set; }

    }
}
