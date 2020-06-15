using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallRutinas_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Name { get; set; }
        public string Nombre_de_la_Rutina { get; set; }
        public string Descripcion { get; set; }
        public string Equipamento { get; set; }
        public string Equipamento_alterno { get; set; }
        public int? Nivel_de_dificultad { get; set; }
        public string Nivel_de_dificultad_Dificultad { get; set; }
        public int? Intensidad { get; set; }
        public string Intensidad_Intensidad { get; set; }
        public int? Duracion_aproximada_minutos { get; set; }
        public int? Genero { get; set; }
        public string Genero_Descripcion { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
