using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDatos_Bancarios_Especialistas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Datos_Bancarios_Especialistas_Folio { get; set; }
        public int Datos_Bancarios_Especialistas_Folio_Especialistas { get; set; }
        public int? Datos_Bancarios_Especialistas_Banco { get; set; }
        public string Datos_Bancarios_Especialistas_Banco_Nombre { get; set; }
        public string Datos_Bancarios_Especialistas_CLABE_Interbancaria { get; set; }
        public string Datos_Bancarios_Especialistas_Num_Cuenta { get; set; }
        public string Datos_Bancarios_Especialistas_Nombre_del_Titular { get; set; }
        public bool? Datos_Bancarios_Especialistas_Principal { get; set; }

    }
}
