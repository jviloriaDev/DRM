using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_ChangePasswordAutorization_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario { get; set; }
        public string Usuario_Name { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }
        public string Email { get; set; }

    }
}
