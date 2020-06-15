using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Enfermedades
{
    /// <summary>
    /// Enfermedades table
    /// </summary>
    public class Enfermedades: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

