using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Periodo_del_dia
{
    /// <summary>
    /// Periodo_del_dia table
    /// </summary>
    public class Periodo_del_dia: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

