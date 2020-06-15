using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_pantalla_Francisco_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int? Archivo { get; set; }
        public string Campo { get; set; }

    }
}
