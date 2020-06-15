using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllRutinas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Rutinas_Folio { get; set; }
        public DateTime? Rutinas_Fecha_de_Registro { get; set; }
        public string Rutinas_Hora_de_Registro { get; set; }
        public int? Rutinas_Usuario_que_Registra { get; set; }
        public string Rutinas_Usuario_que_Registra_Name { get; set; }
        public string Rutinas_Nombre_de_la_Rutina { get; set; }
        public string Rutinas_Descripcion { get; set; }
        public string Rutinas_Equipamento { get; set; }
        public string Rutinas_Equipamento_alterno { get; set; }
        public int? Rutinas_Nivel_de_dificultad { get; set; }
        public string Rutinas_Nivel_de_dificultad_Dificultad { get; set; }
        public int? Rutinas_Intensidad { get; set; }
        public string Rutinas_Intensidad_Intensidad { get; set; }
        public int? Rutinas_Duracion_aproximada_minutos { get; set; }
        public int? Rutinas_Genero { get; set; }
        public string Rutinas_Genero_Descripcion { get; set; }
        public int? Rutinas_Estatus { get; set; }
        public string Rutinas_Estatus_Descripcion { get; set; }

    }
}
