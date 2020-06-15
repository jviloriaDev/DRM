using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Categorias_de_platillos
{
    /// <summary>
    /// Categorias_de_platillos table
    /// </summary>
    public class Categorias_de_platillos: BaseEntity
    {
        public int Clave { get; set; }
        public string Categoria { get; set; }


    }
}

