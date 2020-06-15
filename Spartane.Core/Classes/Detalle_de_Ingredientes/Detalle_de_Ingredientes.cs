using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Unidades_de_Medida;
using Spartane.Core.Classes.Ingredientes;
using Spartane.Core.Classes.Presentacion;
using Spartane.Core.Classes.Marca;
using Spartane.Core.Classes.Platillos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_de_Ingredientes
{
    /// <summary>
    /// Detalle_de_Ingredientes table
    /// </summary>
    public class Detalle_de_Ingredientes: BaseEntity
    {
        public int Clave { get; set; }
        public string Cantidad { get; set; }
        public int? Unidad { get; set; }
        public int? Nombre_del_Ingrediente { get; set; }
        public int? Nombre_de_presentacion { get; set; }
        public int? Nombre_de_Marca { get; set; }
        public int? Platillos { get; set; }

        [ForeignKey("Unidad")]
        public virtual Spartane.Core.Classes.Unidades_de_Medida.Unidades_de_Medida Unidad_Unidades_de_Medida { get; set; }
        [ForeignKey("Nombre_del_Ingrediente")]
        public virtual Spartane.Core.Classes.Ingredientes.Ingredientes Nombre_del_Ingrediente_Ingredientes { get; set; }
        [ForeignKey("Nombre_de_presentacion")]
        public virtual Spartane.Core.Classes.Presentacion.Presentacion Nombre_de_presentacion_Presentacion { get; set; }
        [ForeignKey("Nombre_de_Marca")]
        public virtual Spartane.Core.Classes.Marca.Marca Nombre_de_Marca_Marca { get; set; }
        [ForeignKey("Platillos")]
        public virtual Spartane.Core.Classes.Platillos.Platillos Platillos_Platillos { get; set; }

    }
}

