using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Seleccion_de_Rangos
{
    /// <summary>
    /// Seleccion_de_Rangos table
    /// </summary>
    public class Seleccion_de_Rangos: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

