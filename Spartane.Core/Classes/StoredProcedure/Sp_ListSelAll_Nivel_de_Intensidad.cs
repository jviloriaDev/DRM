using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllNivel_de_Intensidad : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Nivel_de_Intensidad_Folio { get; set; }
        public string Nivel_de_Intensidad_Intensidad { get; set; }

    }
}
