using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallPlatillos_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Name { get; set; }
        public string Nombre_de_Platillo { get; set; }
        public int? Imagen { get; set; }
        public int? Calorias { get; set; }
        public string Calorias_Cantidad { get; set; }
        public int? Dificultad { get; set; }
        public string Dificultad_Categoria { get; set; }
        public int? Categoria_del_Platillo { get; set; }
        public string Categoria_del_Platillo_Categoria { get; set; }
        public int? Tiempo_de_comida { get; set; }
        public string Tiempo_de_comida_Comida { get; set; }
        public int? Tipo_de_comida { get; set; }
        public string Tipo_de_comida_Tipo_de_comida { get; set; }
        public int? Caracteristicas { get; set; }
        public string Caracteristicas_Caracteristicas { get; set; }
        public string Calificacion { get; set; }
        public string Modo_de_Preparacion { get; set; }

    }
}
