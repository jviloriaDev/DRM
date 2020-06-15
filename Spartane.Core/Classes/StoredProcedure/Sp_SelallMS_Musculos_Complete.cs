using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMS_Musculos_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Ejercicios { get; set; }
        public int? Musculo { get; set; }
        public string Musculo_Descripcion { get; set; }

    }
}
