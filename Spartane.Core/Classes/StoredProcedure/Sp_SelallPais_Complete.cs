using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallPais_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre_del_Pais { get; set; }
        public string Abreviatura { get; set; }
        public string Codigo { get; set; }

    }
}
