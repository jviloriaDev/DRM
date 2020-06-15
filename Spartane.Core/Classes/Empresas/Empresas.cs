using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Tipos_de_Empresa;
using Spartane.Core.Classes.Estado;
using Spartane.Core.Classes.Pais;
using Spartane.Core.Classes.Estatus;
using Spartane.Core.Classes.Regimenes_Fiscales;
using Spartane.Core.Classes.Estado;
using Spartane.Core.Classes.Pais;
using Spartane.Core.Classes.Spartane_File;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Empresas
{
    /// <summary>
    /// Empresas table
    /// </summary>
    public class Empresas: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Nombre_de_la_Empresa { get; set; }
        public int? Tipo_de_Empresa { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Calle { get; set; }
        public string Numero_exterior { get; set; }
        public string Numero_interior { get; set; }
        public string Colonia { get; set; }
        public int? CP { get; set; }
        public string Ciudad { get; set; }
        public int? Estado { get; set; }
        public int? Pais { get; set; }
        public int? Estatus { get; set; }
        public int? Regimen_Fiscal { get; set; }
        public string Nombre_o_Razon_Social { get; set; }
        public string RFC { get; set; }
        public string Calle_Fiscal { get; set; }
        public string Numero_exterior_Fiscal { get; set; }
        public string Numero_interior_Fiscal { get; set; }
        public string Colonia_Fiscal { get; set; }
        public int? CP_Fiscal { get; set; }
        public string Ciudad_Fiscal { get; set; }
        public int? Estado_Fiscal { get; set; }
        public int? Pais_Fiscal { get; set; }
        public string Telefono_Fiscal { get; set; }
        public string Fax { get; set; }
        public string Nombres_del_Representante_Legal { get; set; }
        public string Apellido_Paterno_del_Representante_Legal { get; set; }
        public string Apellido_Materno_del_Representante_Legal { get; set; }
        public string Nombre_Completo_del_Representante_Legal { get; set; }
        public int? Cedula_Fiscal { get; set; }
        //public string Cedula_Fiscal_URL { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Tipo_de_Empresa")]
        public virtual Spartane.Core.Classes.Tipos_de_Empresa.Tipos_de_Empresa Tipo_de_Empresa_Tipos_de_Empresa { get; set; }
        [ForeignKey("Estado")]
        public virtual Spartane.Core.Classes.Estado.Estado Estado_Estado { get; set; }
        [ForeignKey("Pais")]
        public virtual Spartane.Core.Classes.Pais.Pais Pais_Pais { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus.Estatus Estatus_Estatus { get; set; }
        [ForeignKey("Regimen_Fiscal")]
        public virtual Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales Regimen_Fiscal_Regimenes_Fiscales { get; set; }
        [ForeignKey("Estado_Fiscal")]
        public virtual Spartane.Core.Classes.Estado.Estado Estado_Fiscal_Estado { get; set; }
        [ForeignKey("Pais_Fiscal")]
        public virtual Spartane.Core.Classes.Pais.Pais Pais_Fiscal_Pais { get; set; }
        [ForeignKey("Cedula_Fiscal")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Cedula_Fiscal_Spartane_File { get; set; }

    }
}

