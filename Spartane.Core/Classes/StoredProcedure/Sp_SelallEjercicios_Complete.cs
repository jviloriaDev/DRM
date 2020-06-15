using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallEjercicios_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Name { get; set; }
        public string Nombre_del_Ejercicio { get; set; }
        public string Descripcion_del_Ejercicio { get; set; }
        public int? Tipo_de_Ejercicio { get; set; }
        public string Tipo_de_Ejercicio_Descripcion { get; set; }
        public int? Nivel_de_dificultad { get; set; }
        public string Nivel_de_dificultad_Dificultad { get; set; }
        public int? Sexo { get; set; }
        public string Sexo_Descripcion { get; set; }
        public int? Musculos_trabajados { get; set; }
        public int? Imagen { get; set; }
        public int? Video { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
