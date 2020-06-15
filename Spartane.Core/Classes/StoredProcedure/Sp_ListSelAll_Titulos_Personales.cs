using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTitulos_Personales : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Titulos_Personales_Clave { get; set; }
        public string Titulos_Personales_Descripcion { get; set; }

    }
}
