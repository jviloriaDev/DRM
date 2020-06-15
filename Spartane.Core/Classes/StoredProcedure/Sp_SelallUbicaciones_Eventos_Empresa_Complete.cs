using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallUbicaciones_Eventos_Empresa_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Name { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Cupo { get; set; }
        public int? Ubicacion_externa { get; set; }
        public string Ubicacion_externa_Descripcion { get; set; }
        public string Nombre_del_Lugar { get; set; }
        public int? Empresa { get; set; }
        public string Empresa_Nombre_de_la_Empresa { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
