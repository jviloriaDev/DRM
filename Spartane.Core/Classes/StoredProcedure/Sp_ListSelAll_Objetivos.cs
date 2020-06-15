using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllObjetivos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Objetivos_Clave { get; set; }
        public string Objetivos_Descripcion { get; set; }

    }
}
