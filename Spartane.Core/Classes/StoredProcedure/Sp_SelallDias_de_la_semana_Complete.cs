using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDias_de_la_semana_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public string Texto { get; set; }
        public string Dia { get; set; }

    }
}
