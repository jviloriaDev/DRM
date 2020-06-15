using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Antecedentes_Familiares_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Pacientes { get; set; }
        public int? Enfermedad { get; set; }
        public string Enfermedad_Descripcion { get; set; }
        public int? Parentesco { get; set; }
        public string Parentesco_Descripcion { get; set; }

    }
}
