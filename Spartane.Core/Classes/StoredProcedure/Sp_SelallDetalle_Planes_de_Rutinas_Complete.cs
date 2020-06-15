using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Planes_de_Rutinas_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Planes_de_Rutinas { get; set; }
        public int? Numero_de_Dia { get; set; }
        public string Numero_de_Dia_Dia { get; set; }
        public DateTime? Fecha { get; set; }
        public bool? Realizado { get; set; }

    }
}
