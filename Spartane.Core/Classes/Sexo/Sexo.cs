using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Sexo
{
    /// <summary>
    /// Sexo table
    /// </summary>
    public class Sexo: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

