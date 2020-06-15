using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Tipo_Paciente
{
    /// <summary>
    /// Tipo_Paciente table
    /// </summary>
    public class Tipo_Paciente: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int? Clave_Rol { get; set; }


    }
}

