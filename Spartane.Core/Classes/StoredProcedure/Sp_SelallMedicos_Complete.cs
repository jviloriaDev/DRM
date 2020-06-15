using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMedicos_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Name { get; set; }
        public int? Titulo_Personal { get; set; }
        public string Titulo_Personal_Descripcion { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public int? Tipo_de_Especialista { get; set; }
        public string Tipo_de_Especialista_Descripcion { get; set; }
        public int? Foto { get; set; }
        public string Nombre_de_usuario { get; set; }
        public int? Usuario_Registrado { get; set; }
        public string Usuario_Registrado_Name { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public DateTime? Fecha_de_nacimiento { get; set; }
        public int? Pais_de_nacimiento { get; set; }
        public string Pais_de_nacimiento_Nombre_del_Pais { get; set; }
        public int? Entidad_de_nacimiento { get; set; }
        public string Entidad_de_nacimiento_Nombre_del_Estado { get; set; }
        public int? Sexo { get; set; }
        public string Sexo_Descripcion { get; set; }
        public string Email_institucional { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }
        public int? Email_ppal_publico { get; set; }
        public string Email_ppal_publico_Descripcion { get; set; }
        public string Email_de_contacto { get; set; }
        public string Calle { get; set; }
        public string Numero_exterior { get; set; }
        public string Numero_interior { get; set; }
        public string Colonia { get; set; }
        public int? CP { get; set; }
        public string Ciudad { get; set; }
        public int? Estado { get; set; }
        public string Estado_Nombre_del_Estado { get; set; }
        public int? Pais { get; set; }
        public string Pais_Nombre_del_Pais { get; set; }
        public string Telefonos { get; set; }
        public int? En_Hospital { get; set; }
        public string En_Hospital_Descripcion { get; set; }
        public string Nombre_del_Hospital { get; set; }
        public string Piso_hospital { get; set; }
        public string Numero_de_consultorio { get; set; }
        public int? Se_ajusta_tabulador { get; set; }
        public string Se_ajusta_tabulador_Descripcion { get; set; }
        public int? Profesion { get; set; }
        public string Profesion_Descripcion { get; set; }
        public int? Especialidad { get; set; }
        public string Especialidad_Especialidad { get; set; }
        public string Resumen_Profesional { get; set; }
        public int? Regimen_Fiscal { get; set; }
        public string Regimen_Fiscal_Descripcion { get; set; }
        public string Nombre_o_Razon_Social { get; set; }
        public string RFC { get; set; }
        public string Calle_Fiscal { get; set; }
        public string Numero_exterior_Fiscal { get; set; }
        public string Numero_interior_Fiscal { get; set; }
        public string Colonia_Fiscal { get; set; }
        public int? CP_Fiscal { get; set; }
        public string Ciudad_Fiscal { get; set; }
        public int? Estado_Fiscal { get; set; }
        public string Estado_Fiscal_Nombre_del_Estado { get; set; }
        public int? Pais_Fiscal { get; set; }
        public string Pais_Fiscal_Nombre_del_Pais { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public int? Cedula_Fiscal_Documento { get; set; }
        public int? Comprobante_de_Domicilio { get; set; }
        public int? Calificacion_Red_de_Medicos { get; set; }
        public int? Banco { get; set; }
        public string Banco_Nombre { get; set; }
        public string CLABE_Interbancaria { get; set; }
        public string Numero_de_Cuenta { get; set; }
        public string Nombre_del_Titular { get; set; }

    }
}
