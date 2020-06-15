using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Respuesta_Logica;
using Spartane.Core.Classes.Empresas;
using Spartane.Core.Classes.Estatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Ubicaciones_Eventos_Empresa
{
    /// <summary>
    /// Ubicaciones_Eventos_Empresa table
    /// </summary>
    public class Ubicaciones_Eventos_Empresa: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Cupo { get; set; }
        public int? Ubicacion_externa { get; set; }
        public string Nombre_del_Lugar { get; set; }
        public int? Empresa { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Ubicacion_externa")]
        public virtual Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica Ubicacion_externa_Respuesta_Logica { get; set; }
        [ForeignKey("Empresa")]
        public virtual Spartane.Core.Classes.Empresas.Empresas Empresa_Empresas { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus.Estatus Estatus_Estatus { get; set; }

    }
}

