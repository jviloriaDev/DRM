using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTipos_de_Empresa : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Tipos_de_Empresa_Clave { get; set; }
        public string Tipos_de_Empresa_Descripcion { get; set; }
        public short? Tipos_de_Empresa_Clave_Rol { get; set; }

    }
}
