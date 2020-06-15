using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_User_Historical_Password : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_User_Historical_Password_Clave { get; set; }
        public DateTime? Spartan_User_Historical_Password_Fecha_de_Registro { get; set; }
        public int? Spartan_User_Historical_Password_Usuario { get; set; }
        public string Spartan_User_Historical_Password_Usuario_Name { get; set; }
        public string Spartan_User_Historical_Password_Password { get; set; }

    }
}
