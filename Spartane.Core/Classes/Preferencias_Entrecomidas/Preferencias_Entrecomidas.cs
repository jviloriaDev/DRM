using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Preferencias_Entrecomidas
{
    /// <summary>
    /// Preferencias_Entrecomidas table
    /// </summary>
    public class Preferencias_Entrecomidas: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

