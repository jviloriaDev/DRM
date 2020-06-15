using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Estado_de_Animo
{
    /// <summary>
    /// Estado_de_Animo table
    /// </summary>
    public class Estado_de_Animo: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

