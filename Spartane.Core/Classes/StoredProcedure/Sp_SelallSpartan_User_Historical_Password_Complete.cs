using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_User_Historical_Password_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public int? Usuario { get; set; }
        public string Usuario_Name { get; set; }
        public string Password { get; set; }

    }
}
