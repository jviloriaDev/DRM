using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Parentescos_Empleados
{
    /// <summary>
    /// Parentescos_Empleados table
    /// </summary>
    public class Parentescos_Empleados: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
}

