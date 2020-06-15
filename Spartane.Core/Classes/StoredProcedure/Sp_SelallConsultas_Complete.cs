using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallConsultas_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registo { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Name { get; set; }
        public DateTime? Fecha_Programada { get; set; }
        public int? Paciente { get; set; }
        public string Paciente_Nombre_Completo { get; set; }
        public int? Edad { get; set; }
        public string Nombre_del_padre { get; set; }
        public int? Sexo { get; set; }
        public string Sexo_Descripcion { get; set; }
        public string Email { get; set; }
        public int? Objetivo { get; set; }
        public string Objetivo_Descripcion { get; set; }
        public int? Frecuencia_Cardiaca { get; set; }
        public int? Presion_sistolica { get; set; }
        public int? Presion_diastolica { get; set; }
        public decimal? Peso_actual { get; set; }
        public decimal? Estatura { get; set; }
        public int? Circunferencia_de_cintura_cm { get; set; }
        public int? Circunferencia_de_cadera_cm { get; set; }
        public int? Edad_Metabolica { get; set; }
        public int? Agua_corporal { get; set; }
        public int? Grasa_Visceral { get; set; }
        public int? Grasa_Corporal { get; set; }
        public int? Grasa_Corporal_kg { get; set; }
        public int? Masa_Muscular_kg { get; set; }
        public int? Semana_de_gestacion { get; set; }
        public int? IMC { get; set; }
        public int? IMC_Pediatria { get; set; }
        public string IMC_Pediatria_Descripcion { get; set; }
        public int? Interpretacion_IMC { get; set; }
        public string Interpretacion_IMC_Descripcion { get; set; }
        public int? Consumo_de_agua_resultado { get; set; }
        public int? Interpretacion_agua { get; set; }
        public string Interpretacion_agua_Descripcion { get; set; }
        public int? Frecuencia_cardiaca_en_Esfuerzo { get; set; }
        public int? Interpretacion_frecuencia { get; set; }
        public string Interpretacion_frecuencia_Descripcion { get; set; }
        public int? Indice_cintura_cadera { get; set; }
        public int? Interpretacion_indice { get; set; }
        public string Interpretacion_indice_Descripcion { get; set; }
        public int? Dificultad_de_Rutina_de_Ejercicios { get; set; }
        public int? Interpretacion_dificultad { get; set; }
        public string Interpretacion_dificultad_Descripcion { get; set; }
        public int? Calorias { get; set; }
        public int? Interpretacion_calorias { get; set; }
        public string Interpretacion_calorias_Descripcion { get; set; }
        public string Observaciones { get; set; }
        public DateTime? Fecha_siguiente_Consulta { get; set; }

    }
}
