using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDias_de_la_semana : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Dias_de_la_semana_Clave { get; set; }
        public string Dias_de_la_semana_Texto { get; set; }
        public string Dias_de_la_semana_Dia { get; set; }

    }
}
