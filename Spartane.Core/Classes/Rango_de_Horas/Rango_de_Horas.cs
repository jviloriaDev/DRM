using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Rango_de_Horas
{
    /// <summary>
    /// Rango_de_Horas table
    /// </summary>
    public class Rango_de_Horas: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

