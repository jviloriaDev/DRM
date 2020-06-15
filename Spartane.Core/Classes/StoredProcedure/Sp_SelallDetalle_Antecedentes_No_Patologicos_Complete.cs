using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Antecedentes_No_Patologicos_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Pacientes { get; set; }
        public int? Sustancia { get; set; }
        public string Sustancia_Descripcion { get; set; }
        public int? Frecuencia { get; set; }
        public string Frecuencia_Descripcion { get; set; }
        public int? Cantidad { get; set; }

    }
}
