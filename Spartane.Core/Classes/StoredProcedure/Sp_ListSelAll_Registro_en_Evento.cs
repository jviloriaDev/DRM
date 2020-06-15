using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllRegistro_en_Evento : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Registro_en_Evento_Folio { get; set; }
        public DateTime? Registro_en_Evento_Fecha_de_Registro { get; set; }
        public string Registro_en_Evento_Hora_de_Registro { get; set; }
        public int? Registro_en_Evento_Usuario_que_Registra { get; set; }
        public string Registro_en_Evento_Usuario_que_Registra_Name { get; set; }
        public int? Registro_en_Evento_Evento { get; set; }
        public string Registro_en_Evento_Evento_Nombre_del_Evento { get; set; }
        public string Registro_en_Evento_Descripcion { get; set; }
        public DateTime? Registro_en_Evento_Fecha_inicio_del_Evento { get; set; }
        public DateTime? Registro_en_Evento_Fecha_fin_del_Evento { get; set; }
        public string Registro_en_Evento_Lugar { get; set; }

    }
}
