using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallProveedores_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Name { get; set; }
        public string Nombre_del_Proveedor { get; set; }
        public int? Tipo_de_Proveedor { get; set; }
        public string Tipo_de_Proveedor_Descripcion { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Nombre_de_Usuario { get; set; }
        public int? Usuario_Registrado { get; set; }
        public string Usuario_Registrado_Name { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public DateTime? Fecha_de_Nacimiento { get; set; }
        public int? Pais_de_nacimiento { get; set; }
        public string Pais_de_nacimiento_Nombre_del_Pais { get; set; }
        public int? Entidad_de_nacimiento { get; set; }
        public string Entidad_de_nacimiento_Nombre_del_Estado { get; set; }
        public int? Sexo { get; set; }
        public string Sexo_Descripcion { get; set; }
        public int? Regimen_Fiscal { get; set; }
        public string Regimen_Fiscal_Descripcion { get; set; }
        public string Nombre_o_Razon_Social { get; set; }
        public string RFC { get; set; }
        public string Calle_Fiscal { get; set; }
        public int? Numero_exterior_Fiscal { get; set; }
        public int? Numero_interior_Fiscal { get; set; }
        public string Colonia_Fiscal { get; set; }
        public int? C_P__Fiscal { get; set; }
        public string Ciudad_Fiscal { get; set; }
        public int? Estado_Fiscal { get; set; }
        public string Estado_Fiscal_Nombre_del_Estado { get; set; }
        public int? Pais_Fiscal { get; set; }
        public string Pais_Fiscal_Nombre_del_Pais { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }

    }
}
