using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Interpretacion_corporal
{
    /// <summary>
    /// Interpretacion_corporal table
    /// </summary>
    public class Interpretacion_corporal: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
}

