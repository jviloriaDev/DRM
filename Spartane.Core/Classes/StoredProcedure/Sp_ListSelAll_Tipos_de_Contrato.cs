using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTipos_de_Contrato : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Tipos_de_Contrato_Clave { get; set; }
        public string Tipos_de_Contrato_Descripcion { get; set; }

    }
}
