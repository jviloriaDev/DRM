using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartanChangePasswordAutorizationEstatus : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int SpartanChangePasswordAutorizationEstatus_Clave { get; set; }
        public string SpartanChangePasswordAutorizationEstatus_Descripcion { get; set; }

    }
}
