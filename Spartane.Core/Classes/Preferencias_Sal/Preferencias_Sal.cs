using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Preferencias_Sal
{
    /// <summary>
    /// Preferencias_Sal table
    /// </summary>
    public class Preferencias_Sal: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

