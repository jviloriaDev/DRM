using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallUnidades_de_Medida_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public string Unidad { get; set; }
        public string Abreviacion { get; set; }
        public string Texto_Singular { get; set; }
        public string Texto_Plural { get; set; }

    }
}
