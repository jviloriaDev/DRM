using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.TTUsuarios
{
   /// <summary>
    /// TTUsuarios table
    /// </summary>
    public class TTUsuarios: BaseEntity
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Clave_de_Acceso { get; set; }
        public string Contrasena { get; set; }
        public bool?  Activo { get; set; }
        public int? idGrupoUsuarios { get; set; }


    }
}

