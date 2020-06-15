using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllConsultas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Consultas_Folio { get; set; }
        public DateTime? Consultas_Fecha_de_Registo { get; set; }
        public string Consultas_Hora_de_Registro { get; set; }
        public int? Consultas_Usuario_que_Registra { get; set; }
        public string Consultas_Usuario_que_Registra_Name { get; set; }
        public DateTime? Consultas_Fecha_Programada { get; set; }
        public int? Consultas_Paciente { get; set; }
        public string Consultas_Paciente_Nombre_Completo { get; set; }
        public int? Consultas_Edad { get; set; }
        public string Consultas_Nombre_del_padre { get; set; }
        public int? Consultas_Sexo { get; set; }
        public string Consultas_Sexo_Descripcion { get; set; }
        public string Consultas_Email { get; set; }
        public int? Consultas_Objetivo { get; set; }
        public string Consultas_Objetivo_Descripcion { get; set; }
        public int? Consultas_Frecuencia_Cardiaca { get; set; }
        public int? Consultas_Presion_sistolica { get; set; }
        public int? Consultas_Presion_diastolica { get; set; }
        public decimal? Consultas_Peso_actual { get; set; }
        public decimal? Consultas_Estatura { get; set; }
        public int? Consultas_Circunferencia_de_cintura_cm { get; set; }
        public int? Consultas_Circunferencia_de_cadera_cm { get; set; }
        public int? Consultas_Edad_Metabolica { get; set; }
        public int? Consultas_Agua_corporal { get; set; }
        public int? Consultas_Grasa_Visceral { get; set; }
        public int? Consultas_Grasa_Corporal { get; set; }
        public int? Consultas_Grasa_Corporal_kg { get; set; }
        public int? Consultas_Masa_Muscular_kg { get; set; }
        public int? Consultas_Semana_de_gestacion { get; set; }
        public int? Consultas_IMC { get; set; }
        public int? Consultas_IMC_Pediatria { get; set; }
        public string Consultas_IMC_Pediatria_Descripcion { get; set; }
        public int? Consultas_Interpretacion_IMC { get; set; }
        public string Consultas_Interpretacion_IMC_Descripcion { get; set; }
        public int? Consultas_Consumo_de_agua_resultado { get; set; }
        public int? Consultas_Interpretacion_agua { get; set; }
        public string Consultas_Interpretacion_agua_Descripcion { get; set; }
        public int? Consultas_Frecuencia_cardiaca_en_Esfuerzo { get; set; }
        public int? Consultas_Interpretacion_frecuencia { get; set; }
        public string Consultas_Interpretacion_frecuencia_Descripcion { get; set; }
        public int? Consultas_Indice_cintura_cadera { get; set; }
        public int? Consultas_Interpretacion_indice { get; set; }
        public string Consultas_Interpretacion_indice_Descripcion { get; set; }
        public int? Consultas_Dificultad_de_Rutina_de_Ejercicios { get; set; }
        public int? Consultas_Interpretacion_dificultad { get; set; }
        public string Consultas_Interpretacion_dificultad_Descripcion { get; set; }
        public int? Consultas_Calorias { get; set; }
        public int? Consultas_Interpretacion_calorias { get; set; }
        public string Consultas_Interpretacion_calorias_Descripcion { get; set; }
        public string Consultas_Observaciones { get; set; }
        public DateTime? Consultas_Fecha_siguiente_Consulta { get; set; }

    }
}
