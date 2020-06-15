using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllProfesiones : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Profesiones_Clave { get; set; }
        public string Profesiones_Descripcion { get; set; }

    }
}
