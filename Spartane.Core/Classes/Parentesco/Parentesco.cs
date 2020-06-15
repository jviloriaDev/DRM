using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Parentesco
{
    /// <summary>
    /// Parentesco table
    /// </summary>
    public class Parentesco: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

