using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallEventos_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Name { get; set; }
        public int? Empresa { get; set; }
        public string Empresa_Nombre_de_la_Empresa { get; set; }
        public string Nombre_del_Evento { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha_inicio_del_Evento { get; set; }
        public DateTime? Fecha_fin_del_Evento { get; set; }
        public int? Cantidad_de_dias { get; set; }
        public int? Evento_en_Empresa { get; set; }
        public string Evento_en_Empresa_Descripcion { get; set; }
        public string Nombre_del_Lugar { get; set; }
        public string Calle { get; set; }
        public string Numero_exterior { get; set; }
        public string Numero_interior { get; set; }
        public string Colonia { get; set; }
        public string CP { get; set; }
        public string Ciudad { get; set; }
        public int? Estado { get; set; }
        public string Estado_Nombre_del_Estado { get; set; }
        public int? Pais { get; set; }
        public string Pais_Nombre_del_Pais { get; set; }
        public int? Permite_Familiares { get; set; }
        public string Permite_Familiares_Descripcion { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
