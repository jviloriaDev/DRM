using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMarca : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Marca_Clave { get; set; }
        public string Marca_Descripcion { get; set; }

    }
}
