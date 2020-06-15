using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_ChangePasswordAutorization : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_ChangePasswordAutorization_Clave { get; set; }
        public DateTime? Spartan_ChangePasswordAutorization_Fecha_de_Registro { get; set; }
        public string Spartan_ChangePasswordAutorization_Hora_de_Registro { get; set; }
        public int? Spartan_ChangePasswordAutorization_Usuario { get; set; }
        public string Spartan_ChangePasswordAutorization_Usuario_Name { get; set; }
        public int? Spartan_ChangePasswordAutorization_Estatus { get; set; }
        public string Spartan_ChangePasswordAutorization_Estatus_Descripcion { get; set; }
        public string Spartan_ChangePasswordAutorization_Email { get; set; }

    }
}
