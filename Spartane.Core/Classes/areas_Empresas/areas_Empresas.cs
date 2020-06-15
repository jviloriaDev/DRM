using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.areas_Empresas
{
    /// <summary>
    /// areas_Empresas table
    /// </summary>
    public class areas_Empresas: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }


    }
}

