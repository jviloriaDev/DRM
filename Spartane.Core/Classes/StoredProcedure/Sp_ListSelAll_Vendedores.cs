using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllVendedores : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Vendedores_Folio { get; set; }
        public DateTime? Vendedores_Fecha_de_Registro { get; set; }
        public string Vendedores_Hora_de_Registro { get; set; }
        public int? Vendedores_Usuario_que_Registra { get; set; }
        public string Vendedores_Usuario_que_Registra_Name { get; set; }
        public string Vendedores_Nombres { get; set; }
        public string Vendedores_Apellido_Paterno { get; set; }
        public string Vendedores_Apellido_Materno { get; set; }
        public string Vendedores_Nombre_Completo { get; set; }
        public string Vendedores_Nombre_de_Usuario { get; set; }
        public int? Vendedores_Usuario_Registrado { get; set; }
        public string Vendedores_Usuario_Registrado_Name { get; set; }
        public string Vendedores_Email { get; set; }
        public string Vendedores_Celular { get; set; }
        public DateTime? Vendedores_Fecha_de_nacimiento { get; set; }
        public int? Vendedores_Pais_de_nacimiento { get; set; }
        public string Vendedores_Pais_de_nacimiento_Nombre_del_Pais { get; set; }
        public int? Vendedores_Entidad_de_nacimiento { get; set; }
        public string Vendedores_Entidad_de_nacimiento_Nombre_del_Estado { get; set; }
        public int? Vendedores_Sexo { get; set; }
        public string Vendedores_Sexo_Descripcion { get; set; }
        public int? Vendedores_Estatus { get; set; }
        public string Vendedores_Estatus_Descripcion { get; set; }
        public int? Vendedores_Banco { get; set; }
        public string Vendedores_Banco_Nombre { get; set; }
        public string Vendedores_CLABE_Interbancaria { get; set; }
        public string Vendedores_Numero_de_Cuenta { get; set; }
        public string Vendedores_Nombre_del_Titular { get; set; }

    }
}
