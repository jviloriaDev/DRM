using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Tipos_de_Especialistas
{
    /// <summary>
    /// Tipos_de_Especialistas table
    /// </summary>
    public class Tipos_de_Especialistas: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public short? Clave_Rol { get; set; }


    }
}

