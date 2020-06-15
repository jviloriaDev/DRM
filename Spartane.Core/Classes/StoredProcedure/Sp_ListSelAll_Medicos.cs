using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMedicos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Medicos_Folio { get; set; }
        public DateTime? Medicos_Fecha_de_Registro { get; set; }
        public string Medicos_Hora_de_Registro { get; set; }
        public int? Medicos_Usuario_que_Registra { get; set; }
        public string Medicos_Usuario_que_Registra_Name { get; set; }
        public int? Medicos_Titulo_Personal { get; set; }
        public string Medicos_Titulo_Personal_Descripcion { get; set; }
        public string Medicos_Nombres { get; set; }
        public string Medicos_Apellido_Paterno { get; set; }
        public string Medicos_Apellido_Materno { get; set; }
        public string Medicos_Nombre_Completo { get; set; }
        public int? Medicos_Tipo_de_Especialista { get; set; }
        public string Medicos_Tipo_de_Especialista_Descripcion { get; set; }
        public int? Medicos_Foto { get; set; }
        public string Medicos_Foto_Nombre { get; set; }
        public string Medicos_Nombre_de_usuario { get; set; }
        public int? Medicos_Usuario_Registrado { get; set; }
        public string Medicos_Usuario_Registrado_Name { get; set; }
        public string Medicos_Email { get; set; }
        public string Medicos_Celular { get; set; }
        public DateTime? Medicos_Fecha_de_nacimiento { get; set; }
        public int? Medicos_Pais_de_nacimiento { get; set; }
        public string Medicos_Pais_de_nacimiento_Nombre_del_Pais { get; set; }
        public int? Medicos_Entidad_de_nacimiento { get; set; }
        public string Medicos_Entidad_de_nacimiento_Nombre_del_Estado { get; set; }
        public int? Medicos_Sexo { get; set; }
        public string Medicos_Sexo_Descripcion { get; set; }
        public string Medicos_Email_institucional { get; set; }
        public int? Medicos_Estatus { get; set; }
        public string Medicos_Estatus_Descripcion { get; set; }
        public int? Medicos_Email_ppal_publico { get; set; }
        public string Medicos_Email_ppal_publico_Descripcion { get; set; }
        public string Medicos_Email_de_contacto { get; set; }
        public string Medicos_Calle { get; set; }
        public string Medicos_Numero_exterior { get; set; }
        public string Medicos_Numero_interior { get; set; }
        public string Medicos_Colonia { get; set; }
        public int? Medicos_CP { get; set; }
        public string Medicos_Ciudad { get; set; }
        public int? Medicos_Estado { get; set; }
        public string Medicos_Estado_Nombre_del_Estado { get; set; }
        public int? Medicos_Pais { get; set; }
        public string Medicos_Pais_Nombre_del_Pais { get; set; }
        public string Medicos_Telefonos { get; set; }
        public int? Medicos_En_Hospital { get; set; }
        public string Medicos_En_Hospital_Descripcion { get; set; }
        public string Medicos_Nombre_del_Hospital { get; set; }
        public string Medicos_Piso_hospital { get; set; }
        public string Medicos_Numero_de_consultorio { get; set; }
        public int? Medicos_Se_ajusta_tabulador { get; set; }
        public string Medicos_Se_ajusta_tabulador_Descripcion { get; set; }
        public int? Medicos_Profesion { get; set; }
        public string Medicos_Profesion_Descripcion { get; set; }
        public int? Medicos_Especialidad { get; set; }
        public string Medicos_Especialidad_Especialidad { get; set; }
        public string Medicos_Resumen_Profesional { get; set; }
        public int? Medicos_Regimen_Fiscal { get; set; }
        public string Medicos_Regimen_Fiscal_Descripcion { get; set; }
        public string Medicos_Nombre_o_Razon_Social { get; set; }
        public string Medicos_RFC { get; set; }
        public string Medicos_Calle_Fiscal { get; set; }
        public string Medicos_Numero_exterior_Fiscal { get; set; }
        public string Medicos_Numero_interior_Fiscal { get; set; }
        public string Medicos_Colonia_Fiscal { get; set; }
        public int? Medicos_CP_Fiscal { get; set; }
        public string Medicos_Ciudad_Fiscal { get; set; }
        public int? Medicos_Estado_Fiscal { get; set; }
        public string Medicos_Estado_Fiscal_Nombre_del_Estado { get; set; }
        public int? Medicos_Pais_Fiscal { get; set; }
        public string Medicos_Pais_Fiscal_Nombre_del_Pais { get; set; }
        public string Medicos_Telefono { get; set; }
        public string Medicos_Fax { get; set; }
        public int? Medicos_Cedula_Fiscal_Documento { get; set; }
        public string Medicos_Cedula_Fiscal_Documento_Nombre { get; set; }
        public int? Medicos_Comprobante_de_Domicilio { get; set; }
        public string Medicos_Comprobante_de_Domicilio_Nombre { get; set; }
        public int? Medicos_Calificacion_Red_de_Medicos { get; set; }
        public int? Medicos_Banco { get; set; }
        public string Medicos_Banco_Nombre { get; set; }
        public string Medicos_CLABE_Interbancaria { get; set; }
        public string Medicos_Numero_de_Cuenta { get; set; }
        public string Medicos_Nombre_del_Titular { get; set; }

    }
}
