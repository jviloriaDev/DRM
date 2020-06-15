using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Estado_Civil
{
    /// <summary>
    /// Estado_Civil table
    /// </summary>
    public class Estado_Civil: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

