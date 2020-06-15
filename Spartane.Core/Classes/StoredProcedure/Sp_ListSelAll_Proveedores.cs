using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllProveedores : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Proveedores_Folio { get; set; }
        public DateTime? Proveedores_Fecha_de_Registro { get; set; }
        public string Proveedores_Hora_de_Registro { get; set; }
        public int? Proveedores_Usuario_que_Registra { get; set; }
        public string Proveedores_Usuario_que_Registra_Name { get; set; }
        public string Proveedores_Nombre_del_Proveedor { get; set; }
        public int? Proveedores_Tipo_de_Proveedor { get; set; }
        public string Proveedores_Tipo_de_Proveedor_Descripcion { get; set; }
        public int? Proveedores_Estatus { get; set; }
        public string Proveedores_Estatus_Descripcion { get; set; }
        public string Proveedores_Nombres { get; set; }
        public string Proveedores_Apellido_Paterno { get; set; }
        public string Proveedores_Apellido_Materno { get; set; }
        public string Proveedores_Nombre_Completo { get; set; }
        public string Proveedores_Nombre_de_Usuario { get; set; }
        public int? Proveedores_Usuario_Registrado { get; set; }
        public string Proveedores_Usuario_Registrado_Name { get; set; }
        public string Proveedores_Email { get; set; }
        public string Proveedores_Celular { get; set; }
        public DateTime? Proveedores_Fecha_de_Nacimiento { get; set; }
        public int? Proveedores_Pais_de_nacimiento { get; set; }
        public string Proveedores_Pais_de_nacimiento_Nombre_del_Pais { get; set; }
        public int? Proveedores_Entidad_de_nacimiento { get; set; }
        public string Proveedores_Entidad_de_nacimiento_Nombre_del_Estado { get; set; }
        public int? Proveedores_Sexo { get; set; }
        public string Proveedores_Sexo_Descripcion { get; set; }
        public int? Proveedores_Regimen_Fiscal { get; set; }
        public string Proveedores_Regimen_Fiscal_Descripcion { get; set; }
        public string Proveedores_Nombre_o_Razon_Social { get; set; }
        public string Proveedores_RFC { get; set; }
        public string Proveedores_Calle_Fiscal { get; set; }
        public int? Proveedores_Numero_exterior_Fiscal { get; set; }
        public int? Proveedores_Numero_interior_Fiscal { get; set; }
        public string Proveedores_Colonia_Fiscal { get; set; }
        public int? Proveedores_C_P__Fiscal { get; set; }
        public string Proveedores_Ciudad_Fiscal { get; set; }
        public int? Proveedores_Estado_Fiscal { get; set; }
        public string Proveedores_Estado_Fiscal_Nombre_del_Estado { get; set; }
        public int? Proveedores_Pais_Fiscal { get; set; }
        public string Proveedores_Pais_Fiscal_Nombre_del_Pais { get; set; }
        public string Proveedores_Telefono { get; set; }
        public string Proveedores_Fax { get; set; }

    }
}
