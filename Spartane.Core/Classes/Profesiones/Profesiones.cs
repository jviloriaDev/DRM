using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Profesiones
{
    /// <summary>
    /// Profesiones table
    /// </summary>
    public class Profesiones: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

