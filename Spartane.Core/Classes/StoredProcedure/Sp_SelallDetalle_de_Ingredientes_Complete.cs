using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_de_Ingredientes_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public string Cantidad { get; set; }
        public int? Unidad { get; set; }
        public string Unidad_Unidad { get; set; }
        public int? Nombre_del_Ingrediente { get; set; }
        public string Nombre_del_Ingrediente_Nombre_Ingrediente { get; set; }
        public int? Nombre_de_presentacion { get; set; }
        public string Nombre_de_presentacion_Descripcion { get; set; }
        public int? Nombre_de_Marca { get; set; }
        public string Nombre_de_Marca_Descripcion { get; set; }
        public int Platillos { get; set; }

    }
}
