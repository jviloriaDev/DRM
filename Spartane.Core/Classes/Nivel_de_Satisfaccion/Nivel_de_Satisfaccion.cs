using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Nivel_de_Satisfaccion
{
    /// <summary>
    /// Nivel_de_Satisfaccion table
    /// </summary>
    public class Nivel_de_Satisfaccion: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

