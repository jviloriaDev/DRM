using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEmpresas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Empresas_Folio { get; set; }
        public DateTime? Empresas_Fecha_de_Registro { get; set; }
        public string Empresas_Hora_de_Registro { get; set; }
        public int? Empresas_Usuario_que_Registra { get; set; }
        public string Empresas_Usuario_que_Registra_Name { get; set; }
        public string Empresas_Nombre_de_la_Empresa { get; set; }
        public int? Empresas_Tipo_de_Empresa { get; set; }
        public string Empresas_Tipo_de_Empresa_Descripcion { get; set; }
        public string Empresas_Email { get; set; }
        public string Empresas_Telefono { get; set; }
        public string Empresas_Calle { get; set; }
        public string Empresas_Numero_exterior { get; set; }
        public string Empresas_Numero_interior { get; set; }
        public string Empresas_Colonia { get; set; }
        public int? Empresas_CP { get; set; }
        public string Empresas_Ciudad { get; set; }
        public int? Empresas_Estado { get; set; }
        public string Empresas_Estado_Nombre_del_Estado { get; set; }
        public int? Empresas_Pais { get; set; }
        public string Empresas_Pais_Nombre_del_Pais { get; set; }
        public int? Empresas_Estatus { get; set; }
        public string Empresas_Estatus_Descripcion { get; set; }
        public int? Empresas_Regimen_Fiscal { get; set; }
        public string Empresas_Regimen_Fiscal_Descripcion { get; set; }
        public string Empresas_Nombre_o_Razon_Social { get; set; }
        public string Empresas_RFC { get; set; }
        public string Empresas_Calle_Fiscal { get; set; }
        public string Empresas_Numero_exterior_Fiscal { get; set; }
        public string Empresas_Numero_interior_Fiscal { get; set; }
        public string Empresas_Colonia_Fiscal { get; set; }
        public int? Empresas_CP_Fiscal { get; set; }
        public string Empresas_Ciudad_Fiscal { get; set; }
        public int? Empresas_Estado_Fiscal { get; set; }
        public string Empresas_Estado_Fiscal_Nombre_del_Estado { get; set; }
        public int? Empresas_Pais_Fiscal { get; set; }
        public string Empresas_Pais_Fiscal_Nombre_del_Pais { get; set; }
        public string Empresas_Telefono_Fiscal { get; set; }
        public string Empresas_Fax { get; set; }
        public string Empresas_Nombres_del_Representante_Legal { get; set; }
        public string Empresas_Apellido_Paterno_del_Representante_Legal { get; set; }
        public string Empresas_Apellido_Materno_del_Representante_Legal { get; set; }
        public string Empresas_Nombre_Completo_del_Representante_Legal { get; set; }
        public int? Empresas_Cedula_Fiscal { get; set; }
        public string Empresas_Cedula_Fiscal_Nombre { get; set; }

    }
}
