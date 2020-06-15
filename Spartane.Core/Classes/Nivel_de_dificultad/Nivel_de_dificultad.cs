using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Nivel_de_dificultad
{
    /// <summary>
    /// Nivel_de_dificultad table
    /// </summary>
    public class Nivel_de_dificultad: BaseEntity
    {
        public int Folio { get; set; }
        public string Dificultad { get; set; }


    }
}

