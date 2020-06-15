using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Aseguradoras
{
    /// <summary>
    /// Aseguradoras table
    /// </summary>
    public class Aseguradoras: BaseEntity
    {
        public int Folio { get; set; }
        public string Nombre { get; set; }


    }
}

