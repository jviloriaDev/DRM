using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllPlatillos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Platillos_Folio { get; set; }
        public DateTime? Platillos_Fecha_de_Registro { get; set; }
        public string Platillos_Hora_de_Registro { get; set; }
        public int? Platillos_Usuario_que_Registra { get; set; }
        public string Platillos_Usuario_que_Registra_Name { get; set; }
        public string Platillos_Nombre_de_Platillo { get; set; }
        public int? Platillos_Imagen { get; set; }
        public string Platillos_Imagen_Nombre { get; set; }
        public int? Platillos_Calorias { get; set; }
        public string Platillos_Calorias_Cantidad { get; set; }
        public int? Platillos_Dificultad { get; set; }
        public string Platillos_Dificultad_Categoria { get; set; }
        public int? Platillos_Categoria_del_Platillo { get; set; }
        public string Platillos_Categoria_del_Platillo_Categoria { get; set; }
        public int? Platillos_Tiempo_de_comida { get; set; }
        public string Platillos_Tiempo_de_comida_Comida { get; set; }
        public int? Platillos_Tipo_de_comida { get; set; }
        public string Platillos_Tipo_de_comida_Tipo_de_comida { get; set; }
        public int? Platillos_Caracteristicas { get; set; }
        public string Platillos_Caracteristicas_Caracteristicas { get; set; }
        public string Platillos_Calificacion { get; set; }
        public string Platillos_Modo_de_Preparacion { get; set; }

    }
}
