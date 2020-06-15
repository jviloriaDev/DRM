using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Clasificacion_Ingredientes;
using Spartane.Core.Classes.Spartane_File;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Ingredientes
{
    /// <summary>
    /// Ingredientes table
    /// </summary>
    public class Ingredientes: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre_Ingrediente { get; set; }
        public int? Clasificacion { get; set; }
        public int? Imagen { get; set; }
        //public string Imagen_URL { get; set; }
        public string Subgrupo { get; set; }
        public decimal? Cantidad_sugerida { get; set; }
        public string Unidad { get; set; }
        public decimal? Peso_bruto_redondeado_g { get; set; }
        public decimal? Peso_neto_g { get; set; }
        public string Nombre_sistema_anterior { get; set; }

        [ForeignKey("Clasificacion")]
        public virtual Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes Clasificacion_Clasificacion_Ingredientes { get; set; }
        [ForeignKey("Imagen")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Imagen_Spartane_File { get; set; }

    }
}

