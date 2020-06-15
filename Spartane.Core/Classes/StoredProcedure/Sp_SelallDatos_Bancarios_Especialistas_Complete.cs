using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDatos_Bancarios_Especialistas_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Especialistas { get; set; }
        public int? Banco { get; set; }
        public string Banco_Nombre { get; set; }
        public string CLABE_Interbancaria { get; set; }
        public string Num_Cuenta { get; set; }
        public string Nombre_del_Titular { get; set; }
        public bool? Principal { get; set; }

    }
}
