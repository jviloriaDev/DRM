using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllUbicaciones_Eventos_Empresa : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Ubicaciones_Eventos_Empresa_Folio { get; set; }
        public DateTime? Ubicaciones_Eventos_Empresa_Fecha_de_Registro { get; set; }
        public string Ubicaciones_Eventos_Empresa_Hora_de_Registro { get; set; }
        public int? Ubicaciones_Eventos_Empresa_Usuario_que_Registra { get; set; }
        public string Ubicaciones_Eventos_Empresa_Usuario_que_Registra_Name { get; set; }
        public string Ubicaciones_Eventos_Empresa_Nombre { get; set; }
        public string Ubicaciones_Eventos_Empresa_Descripcion { get; set; }
        public int? Ubicaciones_Eventos_Empresa_Cupo { get; set; }
        public int? Ubicaciones_Eventos_Empresa_Ubicacion_externa { get; set; }
        public string Ubicaciones_Eventos_Empresa_Ubicacion_externa_Descripcion { get; set; }
        public string Ubicaciones_Eventos_Empresa_Nombre_del_Lugar { get; set; }
        public int? Ubicaciones_Eventos_Empresa_Empresa { get; set; }
        public string Ubicaciones_Eventos_Empresa_Empresa_Nombre_de_la_Empresa { get; set; }
        public int? Ubicaciones_Eventos_Empresa_Estatus { get; set; }
        public string Ubicaciones_Eventos_Empresa_Estatus_Descripcion { get; set; }

    }
}
