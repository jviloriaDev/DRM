using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallResultados_IMC_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Pacientes { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IMC { get; set; }
        public string Estatus { get; set; }

    }
}
