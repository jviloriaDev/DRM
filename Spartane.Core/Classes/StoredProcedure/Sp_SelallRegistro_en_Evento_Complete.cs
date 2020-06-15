using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallRegistro_en_Evento_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Name { get; set; }
        public int? Evento { get; set; }
        public string Evento_Nombre_del_Evento { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha_inicio_del_Evento { get; set; }
        public DateTime? Fecha_fin_del_Evento { get; set; }
        public string Lugar { get; set; }

    }
}
