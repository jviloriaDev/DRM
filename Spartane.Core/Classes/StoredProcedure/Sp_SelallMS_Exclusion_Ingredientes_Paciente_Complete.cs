using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMS_Exclusion_Ingredientes_Paciente_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Pacientes { get; set; }
        public int? Ingrediente { get; set; }
        public string Ingrediente_Nombre_Ingrediente { get; set; }

    }
}
