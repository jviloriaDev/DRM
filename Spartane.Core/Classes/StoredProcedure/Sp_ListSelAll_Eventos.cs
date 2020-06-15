using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEventos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Eventos_Folio { get; set; }
        public DateTime? Eventos_Fecha_de_Registro { get; set; }
        public string Eventos_Hora_de_Registro { get; set; }
        public int? Eventos_Usuario_que_Registra { get; set; }
        public string Eventos_Usuario_que_Registra_Name { get; set; }
        public int? Eventos_Empresa { get; set; }
        public string Eventos_Empresa_Nombre_de_la_Empresa { get; set; }
        public string Eventos_Nombre_del_Evento { get; set; }
        public string Eventos_Descripcion { get; set; }
        public DateTime? Eventos_Fecha_inicio_del_Evento { get; set; }
        public DateTime? Eventos_Fecha_fin_del_Evento { get; set; }
        public int? Eventos_Cantidad_de_dias { get; set; }
        public int? Eventos_Evento_en_Empresa { get; set; }
        public string Eventos_Evento_en_Empresa_Descripcion { get; set; }
        public string Eventos_Nombre_del_Lugar { get; set; }
        public string Eventos_Calle { get; set; }
        public string Eventos_Numero_exterior { get; set; }
        public string Eventos_Numero_interior { get; set; }
        public string Eventos_Colonia { get; set; }
        public string Eventos_CP { get; set; }
        public string Eventos_Ciudad { get; set; }
        public int? Eventos_Estado { get; set; }
        public string Eventos_Estado_Nombre_del_Estado { get; set; }
        public int? Eventos_Pais { get; set; }
        public string Eventos_Pais_Nombre_del_Pais { get; set; }
        public int? Eventos_Permite_Familiares { get; set; }
        public string Eventos_Permite_Familiares_Descripcion { get; set; }
        public int? Eventos_Estatus { get; set; }
        public string Eventos_Estatus_Descripcion { get; set; }

    }
}
