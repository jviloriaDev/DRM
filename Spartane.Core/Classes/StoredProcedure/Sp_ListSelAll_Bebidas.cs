using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllBebidas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Bebidas_Clave { get; set; }
        public string Bebidas_Descripcion { get; set; }

    }
}
