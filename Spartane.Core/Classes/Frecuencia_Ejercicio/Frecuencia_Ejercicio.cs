using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Frecuencia_Ejercicio
{
    /// <summary>
    /// Frecuencia_Ejercicio table
    /// </summary>
    public class Frecuencia_Ejercicio: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

