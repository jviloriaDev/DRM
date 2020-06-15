using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Spartane.Data;
using Spartane.Data.EF;
using Spartane.Services.CustomAuthentication;
using Spartane.Services.GeneratePDF;
using Spartane.Services.TTUsuarios;
using Spartane.Services.Spartan_Query;
using Spartane.Services.Spartan_Attribute_Type;
using Spartane.Services.Spartan_Control_Type;
using Spartane.Services.Spartan_Event_Type;
using Spartane.Services.Spartan_File;
using Spartane.Services.Spartan_Format;
using Spartane.Services.Spartan_Format_Type;
using Spartane.Services.Spartan_Format_Configuration;
using Spartane.Services.Spartan_Format_Field;
using Spartane.Services.Spartan_Format_Permission_Type;
using Spartane.Services.Spartan_Format_Permissions;
using Spartane.Services.Spartan_Function;
using Spartane.Services.Spartan_Function_Characteristic;
using Spartane.Services.Spartan_Function_Characteristic_Config;
using Spartane.Services.Spartan_Function_Event;
using Spartane.Services.Spartan_Function_Status;
using Spartane.Services.Spartan_Function_Type;
using Spartane.Services.Spartan_Function_Type_Status;
using Spartane.Services.Spartan_Language_Text;
using Spartane.Services.Spartan_Layout_Status;
using Spartane.Services.Spartan_Menu_Orientation;
using Spartane.Services.Spartan_Menu_Style;
using Spartane.Services.Spartan_Method_Clasification;
using Spartane.Services.Spartan_Method_Type;
using Spartane.Services.Spartan_Method_Type_Function;
using Spartane.Services.Spartan_Method_Type_Status;
using Spartane.Services.Spartan_Module;
using Spartane.Services.Spartan_Module_Config;
using Spartane.Services.Spartan_Module_Object;
using Spartane.Services.Spartan_Module_Object_Characteristic;
using Spartane.Services.Spartan_Module_Object_Method;
using Spartane.Services.Spartan_Module_Status;
using Spartane.Services.Spartan_Notice;
using Spartane.Services.Spartan_Notice_Status;
using Spartane.Services.Spartan_Notice_Type;
using Spartane.Services.Spartan_Object;
using Spartane.Services.Spartan_Object_Characteristic;
using Spartane.Services.Spartan_Object_Config;
using Spartane.Services.Spartan_Object_Method;
using Spartane.Services.Spartan_Object_Method_Characteristic;
using Spartane.Services.Spartan_Object_Method_Status;
using Spartane.Services.Spartan_Object_Path;
using Spartane.Services.Spartan_Object_Status;
using Spartane.Services.Spartan_Object_Type;
using Spartane.Services.Spartan_Order_Type;
using Spartane.Services.Spartan_Security_Event_Result;
using Spartane.Services.Spartan_Security_Event_Type;
using Spartane.Services.Spartan_Security_Log;
using Spartane.Services.Spartan_Session_Event_Type;
using Spartane.Services.Spartan_Session_Log;
using Spartane.Services.Spartan_System;
using Spartane.Services.Spartan_System_Language;
using Spartane.Services.Spartan_System_Layout;
using Spartane.Services.Spartan_Token_Type;
using Spartane.Services.Spartan_Transaction_Log;
using Spartane.Services.Spartan_Transition_Event_Type;
using Spartane.Services.Spartan_Transition_Log_Type;
using Spartane.Services.Spartan_User;
using Spartane.Services.Spartan_User_Alert;
using Spartane.Services.Spartan_User_Alert_Status;
using Spartane.Services.Spartan_User_Alert_Type;
using Spartane.Services.Spartan_User_Favorite_List;
using Spartane.Services.Spartan_User_Favorite_Object;
using Spartane.Services.Spartan_User_Most_Used_Object;
using Spartane.Services.Spartan_User_Object_Method_Config;
using Spartane.Services.Spartan_User_Quicklink;
using Spartane.Services.Spartan_User_Role;
using Spartane.Services.Spartan_User_Role_Status;
using Spartane.Services.Spartan_User_Rule_Module;
using Spartane.Services.Spartan_User_Rule_Module_Object;
using Spartane.Services.Spartan_User_Rule_Object_Function;
using Spartane.Services.Spartan_User_Status;
using Spartane.Services.Spartan_BR_Scope;
using Spartane.Services.Spartan_BR_Operation;
using Spartane.Services.Spartan_BR_Process_Event;
using Spartane.Services.Spartan_BR_Condition;
using Spartane.Services.Spartan_BR_Operator_Type;
using Spartane.Services.Spartan_BR_Condition_Operator;
using Spartane.Services.Spartan_BR_Action;
using Spartane.Services.Spartan_BR_Action_Classification;
using Spartane.Services.Spartan_BR_Action_Result;
using Spartane.Services.Spartan_Business_Rule;
using Spartane.Services.Spartan_BR_Actions_True_Detail;
using Spartane.Services.Spartan_BR_Actions_False_Detail;
using Spartane.Services.Spartan_BR_Action_Param_Type;
using Spartane.Services.Spartan_BR_Action_Configuration_Detail;
using Spartane.Services.Spartan_BR_Scope_Detail;
using Spartane.Services.Spartan_BR_Operation_Detail;
using Spartane.Services.Spartan_BR_Process_Event_Detail;
using Spartane.Services.Spartan_BR_Conditions_Detail;
using Spartane.Services.Spartan_Metadata;
using Spartane.Tools;
using Spartane.Services.Spartan_BR_Status;
using Spartane.Services.Spartan_BR_Modifications_Log;
using Spartane.Services.Spartan_BR_Presentation_Control_Type;
using Spartane.Services.Spartan_Attribute_Control_Type;
using Spartane.Services.Spartan_BR_Attribute_Restrictions_Detail;
using Spartane.Services.Spartan_BR_Event_Restrictions_Detail;
using Spartane.Services.Spartan_BR_Operation_Restrictions_Detail;
using Spartane.Services.Spartan_Report;
using Spartane.Services.Spartan_Report_Field_Type;
using Spartane.Services.Spartan_Report_Fields_Detail;
using Spartane.Services.Spartan_Report_Format;
using Spartane.Services.Spartan_Report_Function;
using Spartane.Services.Spartan_Report_Order_Type;
using Spartane.Services.Spartan_Report_Permission_Type;
using Spartane.Services.Spartan_Report_Permissions;
using Spartane.Services.Spartan_Report_Status;
using Spartane.Services.Spartan_Report_Presentation_View;
using Spartane.Services.Spartan_Report_Presentation_Type;
using Spartane.Services.Spartan_Report_Filter;
using Spartane.Core.Classes.Spartan_Additional_Menu;
using Spartane.Services.Spartan_Additional_Menu;

using Spartane.Services.Spartan_Traduction_Concept_Type;
using Spartane.Services.Spartan_Traduction_Detail;
using Spartane.Services.Spartan_Traduction_Language;
using Spartane.Services.Spartan_Traduction_Object;
using Spartane.Services.Spartan_Traduction_Object_Type;
using Spartane.Services.Spartan_Traduction_Process;

using Spartane.Services.Spartan_WorkFlow;
using Spartane.Services.Spartan_WorkFlow_Condition;
using Spartane.Services.Spartan_WorkFlow_Condition_Operator;
using Spartane.Services.Spartan_WorkFlow_Conditions_by_State;
using Spartane.Services.Spartan_WorkFlow_Information_by_State;
using Spartane.Services.Spartan_WorkFlow_Matrix_of_States;
using Spartane.Services.Spartan_WorkFlow_Operator;
using Spartane.Services.Spartan_WorkFlow_Phase_Status;
using Spartane.Services.Spartan_WorkFlow_Phase_Type;
using Spartane.Services.Spartan_WorkFlow_Phases;
using Spartane.Services.Spartan_WorkFlow_Roles_by_State;
using Spartane.Services.Spartan_WorkFlow_State;
using Spartane.Services.Spartan_WorkFlow_Status;
using Spartane.Services.Spartan_WorkFlow_Type_Flow_Control;
using Spartane.Services.Spartan_WorkFlow_Type_Work_Distribution;

using Spartane.Services.SpartanObject;
using Spartane.Services.SpartanChangePasswordAutorizationEstatus;
using Spartane.Services.Spartan_ChangePasswordAutorization;
using Spartane.Services.Spartan_User_Historical_Password;
using Spartane.Services.Spartan_Settings;
using Spartane.Services.Spartan_Report_Advance_Filter;
using Spartane.Services.Spartan_Traduction_Process_Data;
using Spartane.Services.Spartan_Traduction_Process_Workflow;
using Spartane.Services.Spartan_Format_Related;
using Spartane.Services.Spartan_Bitacora_SQL;
using Spartane.Services.Business_Rule_Creation;
using Spartane.Services.Spartan_BR_Complexity;
using Spartane.Services.Spartan_BR_Peer_Review;
using Spartane.Services.Spartan_BR_Rejection_Reason;
using Spartane.Services.Spartan_BR_Testing;
using Spartane.Services.Spartan_BR_History;
using Spartane.Services.Spartan_BR_Type_History;
using System.Web.Mvc;
using Spartane.Services.Template_Dashboard_Editor;
using Spartane.Services.Dashboard_Status;
using Spartane.Services.Dashboard_Editor;
using Spartane.Services.Template_Dashboard_Detail;
using Spartane.Services.Dashboard_Config_Detail;
using Spartane.Services.Antiguedad_Ejercicios;
using Spartane.Services.Bebidas;
using Spartane.Services.Calorias;
using Spartane.Services.Cantidad_Comidas;
using Spartane.Services.Categorias_de_platillos;
using Spartane.Services.Clasificacion_Ingredientes;
using Spartane.Services.Detalle_Antecedentes_Familiares;
using Spartane.Services.Detalle_Antecedentes_No_Patologicos;
using Spartane.Services.Detalle_de_Ingredientes;
using Spartane.Services.Detalle_de_Padecimientos;
using Spartane.Services.Detalle_Examenes_Laboratorio;
using Spartane.Services.Detalle_Preferencia_Bebidas;
using Spartane.Services.Detalle_Terapia_Hormonal;
using Spartane.Services.Dias_de_la_semana;
using Spartane.Services.Dificultad_de_platillos;
using Spartane.Services.Duracion_Ejercicio;
using Spartane.Services.Ejercicios;
using Spartane.Services.Empresas;
using Spartane.Services.Enfermedades;
using Spartane.Services.Estado;
using Spartane.Services.Estado_Civil;
using Spartane.Services.Estado_de_Animo;
using Spartane.Services.Estatus_Paciente;
using Spartane.Services.Estatus_Padecimiento;
using Spartane.Services.Frecuencia_Ejercicio;
using Spartane.Services.Frecuencia_Sustancias;
using Spartane.Services.Indicadores_Laboratorio;
using Spartane.Services.Ingredientes;
using Spartane.Services.Marca;
using Spartane.Services.Medicos;
using Spartane.Services.Nivel_de_Satisfaccion;
using Spartane.Services.Objetivos;
using Spartane.Services.Pacientes;
using Spartane.Services.Padecimientos;
using Spartane.Services.Pais;
using Spartane.Services.Parentesco;
using Spartane.Services.Periodo_del_dia;
using Spartane.Services.Platillos;
using Spartane.Services.Preferencias_Entrecomidas;
using Spartane.Services.Preferencias_Grasas;
using Spartane.Services.Preferencias_Preparacion;
using Spartane.Services.Preferencias_Sal;
using Spartane.Services.Presentacion;
using Spartane.Services.Rango_Consumo_Bebidas;
using Spartane.Services.Rango_de_Horas;
using Spartane.Services.Registro;
using Spartane.Services.Respuesta_Logica;
using Spartane.Services.Resultados_IMC;
using Spartane.Services.Seleccion_de_Rangos;
using Spartane.Services.Sexo;
using Spartane.Services.Suplementos;
using Spartane.Services.Sustancias;
using Spartane.Services.Tiempo_Padecimiento;
using Spartane.Services.Tiempos_de_Comida;
using Spartane.Services.Tipo_de_Dieta;
using Spartane.Services.Tipo_de_Registro;
using Spartane.Services.Tipo_Ejercicio;
using Spartane.Services.Tipo_Modificacion_Alimentos;
using Spartane.Services.Tipo_Paciente;
using Spartane.Services.Unidades_de_Medida;
using Spartane.Services.Consultas;
using Spartane.Services.Estatus;
using Spartane.Services.Profesiones;
using Spartane.Services.Especialidades;
using Spartane.Services.Detalle_Identificacion_Oficial_Medicos;
using Spartane.Services.Identificaciones_Oficiales;
using Spartane.Services.Regimenes_Fiscales;
using Spartane.Services.Interpretacion_de_porcentaje_de_grasa_corporal;
using Spartane.Services.Interpretacion_IMC;
using Spartane.Services.Interpretacion_corporal;
using Spartane.Services.Interpretacion_distribucion_grasa_corporal;
using Spartane.Services.Interpretacion_indice_cintura__cadera;
using Spartane.Services.Interpretacion_consumo_de_agua;
using Spartane.Services.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo;
using Spartane.Services.Interpretacion_Dificultad_de_Rutina_de_Ejercicios;
using Spartane.Services.Interpretacion_Calorias;
using Spartane.Services.Tipo_de_Plan_de_Suscripcion;
using Spartane.Services.Duracion_de_Planes_de_Suscripcion;
using Spartane.Services.Planes_de_Suscripcion;
using Spartane.Services.Estatus_por_Suscripcion;
using Spartane.Services.Detalle_Suscripciones_Paciente;
using Spartane.Services.Detalle_Pagos_Paciente;
using Spartane.Services.Estatus_de_Suscripcion;
using Spartane.Services.Estatus_de_Pago;
using Spartane.Services.Formas_de_Pago;
using Spartane.Services.Frecuencia_de_pago_Pacientes;
using Spartane.Services.Frecuencia_de_pago_Empresas;
using Spartane.Services.Detalle_Resultados_Consultas;
using Spartane.Services.Indicadores_Consultas;
using Spartane.Services.Tipos_de_Especialistas;
using Spartane.Services.Detalle_Titulos_Medicos;
using Spartane.Services.areas_Empresas;
using Spartane.Services.Detalle_Suscripciones_Empresa;
using Spartane.Services.Detalle_Pagos_Empresa;
using Spartane.Services.Detalle_Contactos_Empresa;
using Spartane.Services.Detalle_Contratos_Empresa;
using Spartane.Services.Tipos_de_Contrato;
using Spartane.Services.Detalle_Codigos_Referidos;
using Spartane.Services.Detalle_Convenio_Medicos_Aseguradoras;
using Spartane.Services.Aseguradoras;
using Spartane.Services.Detalle_Planes_de_Suscripcion_Especialistas;
using Spartane.Services.Datos_Bancarios_Especialistas;
using Spartane.Services.Detalle_Pagos_Especialistas;
using Spartane.Services.Planes_de_Suscripcion_Especialistas;
using Spartane.Services.Frecuencia_de_pago_Especialistas;
using Spartane.Services.Bancos;
using Spartane.Services.Eventos;
using Spartane.Services.Detalle_Actividades_Evento;
using Spartane.Services.Estatus_Actividades_Evento;
using Spartane.Services.Estatus_Reservaciones_Actividad;
using Spartane.Services.Tipos_de_Actividades;
using Spartane.Services.Ubicaciones_Eventos_Empresa;
using Spartane.Services.Actividades_del_Evento;
using Spartane.Services.Detalle_Horarios_Actividad;
using Spartane.Services.Parentescos_Empleados;
using Spartane.Services.Registro_en_Evento;
using Spartane.Services.Detalle_Consulta_Actividades_Registro_Evento;
using Spartane.Services.Detalle_Registro_en_Actividad_Evento;
using Spartane.Services.Estatus_Eventos;
using Spartane.Services.MS_Exclusion_Ingredientes_Paciente;
using Spartane.Services.Detalle_Especialistas_Pacientes;
using Spartane.Services.Detalle_Facturacion_Especialistas;
using Spartane.Services.Estatus_Facturas;
using Spartane.Services.Titulos_Personales;
using Spartane.Services.Detalle_Redes_Sociales_Especialista;
using Spartane.Services.Redes_sociales;
using Spartane.Services.MS_Suscripciones_Codigos_Referidos_Especialista;
using Spartane.Services.Motivos;
using Spartane.Services.Solicitud_de_Cita_con_Especialista;
using Spartane.Services.Calificacion;
using Spartane.Services.Asuntos_Asistencia_Telefonica;
using Spartane.Services.Estatus_Llamadas;
using Spartane.Services.Registro_de_Asistencia_Telefonica;
using Spartane.Services.Detalle_Registro_Beneficiarios_Empresa;
using Spartane.Services.Tipos_de_Empresa;
using Spartane.Services.Detalle_Caracteristicas_Ingrediente;
using Spartane.Services.Tipo_de_comida_platillos;
using Spartane.Services.Caracteristicas_platillo;
using Spartane.Services.Detalle_Platillos;
using Spartane.Services.Cantidad_fraccion_platillos;
using Spartane.Services.Pantalla_Francisco;
using Spartane.Services.Detalle_pantalla_Francisco;
using Spartane.Services.Tips_y_Promociones;
using Spartane.Services.Planes_Alimenticios;
using Spartane.Services.Detalle_Planes_Alimenticios;
using Spartane.Services.Planes_de_Rutinas;
using Spartane.Services.Detalle_Planes_de_Rutinas;
using Spartane.Services.Rutinas;
using Spartane.Services.Nivel_de_dificultad;
using Spartane.Services.Nivel_de_Intensidad;
using Spartane.Services.Detalle_Ejercicios_Rutinas;
using Spartane.Services.Musculos;
using Spartane.Services.Equipamiento_para_Ejercicios;
using Spartane.Services.MS_Musculos;
using Spartane.Services.MS_Equipamiento_para_Ejercicios;
using Spartane.Services.Vendedores;
using Spartane.Services.Detalle_Codigos_de_Referencia_Vendedores;
using Spartane.Services.Detalle_Facturacion_Vendedores;
using Spartane.Services.Proveedores;
using Spartane.Services.Tipo_de_proveedor;
using Spartane.Services.Detalle_Sucursales_Proveedores;
using Spartane.Services.Tipo_de_Sucursal;
using Spartane.Services.Detalle_Suscripcion_Red_de_Especialistas_Proveedores;
using Spartane.Services.Planes_de_Suscripcion_Proveedores;
//**@@INCLUDE_DECLARE@@**//


namespace oAuth.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            var builder = new ContainerBuilder();

            var dataSettigs = new DataSettings();
            dataSettigs.DataConnectionString = "name=DefaultConnection";//"data source=VM-SQL2012-01;initial catalog=spartane;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            dataSettigs.DataProvider = "sqlserver";

            builder.Register(x => new EFDataProviderManager(dataSettigs)).As<BaseDataProviderManager>().InstancePerLifetimeScope();
            builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerLifetimeScope();
            builder.Register<IDbContext>(c => new TTObjectContext(dataSettigs.DataConnectionString)).InstancePerLifetimeScope();
            builder.RegisterType<Spartan_QueryService>().As<ISpartan_QueryService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Attribute_TypeService>().As<ISpartan_Attribute_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Control_TypeService>().As<ISpartan_Control_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Event_TypeService>().As<ISpartan_Event_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_FileService>().As<ISpartan_FileService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_FormatService>().As<ISpartan_FormatService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Format_TypeService>().As<ISpartan_Format_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Format_ConfigurationService>().As<ISpartan_Format_ConfigurationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Format_FieldService>().As<ISpartan_Format_FieldService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Format_Permission_TypeService>().As<ISpartan_Format_Permission_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Format_PermissionsService>().As<ISpartan_Format_PermissionsService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Function_Characteristic_ConfigService>().As<ISpartan_Function_Characteristic_ConfigService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Function_CharacteristicService>().As<ISpartan_Function_CharacteristicService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Function_EventService>().As<ISpartan_Function_EventService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Function_StatusService>().As<ISpartan_Function_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Function_Type_StatusService>().As<ISpartan_Function_Type_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Function_TypeService>().As<ISpartan_Function_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_FunctionService>().As<ISpartan_FunctionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Language_TextService>().As<ISpartan_Language_TextService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Layout_StatusService>().As<ISpartan_Layout_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Menu_OrientationService>().As<ISpartan_Menu_OrientationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Menu_StyleService>().As<ISpartan_Menu_StyleService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Method_ClasificationService>().As<ISpartan_Method_ClasificationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Method_Type_FunctionService>().As<ISpartan_Method_Type_FunctionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Method_Type_StatusService>().As<ISpartan_Method_Type_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Method_TypeService>().As<ISpartan_Method_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Module_ConfigService>().As<ISpartan_Module_ConfigService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Module_Object_CharacteristicService>().As<ISpartan_Module_Object_CharacteristicService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Module_Object_MethodService>().As<ISpartan_Module_Object_MethodService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Module_ObjectService>().As<ISpartan_Module_ObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Module_StatusService>().As<ISpartan_Module_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_ModuleService>().As<ISpartan_ModuleService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Notice_StatusService>().As<ISpartan_Notice_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Notice_TypeService>().As<ISpartan_Notice_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_NoticeService>().As<ISpartan_NoticeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Object_CharacteristicService>().As<ISpartan_Object_CharacteristicService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Object_ConfigService>().As<ISpartan_Object_ConfigService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Object_Method_CharacteristicService>().As<ISpartan_Object_Method_CharacteristicService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Object_Method_StatusService>().As<ISpartan_Object_Method_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Object_MethodService>().As<ISpartan_Object_MethodService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Object_PathService>().As<ISpartan_Object_PathService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Object_StatusService>().As<ISpartan_Object_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Object_TypeService>().As<ISpartan_Object_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_ObjectService>().As<ISpartan_ObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Order_TypeService>().As<ISpartan_Order_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Security_Event_ResultService>().As<ISpartan_Security_Event_ResultService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Security_Event_TypeService>().As<ISpartan_Security_Event_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Security_LogService>().As<ISpartan_Security_LogService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Session_Event_TypeService>().As<ISpartan_Session_Event_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Session_LogService>().As<ISpartan_Session_LogService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_System_LanguageService>().As<ISpartan_System_LanguageService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_System_LayoutService>().As<ISpartan_System_LayoutService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_SystemService>().As<ISpartan_SystemService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Token_TypeService>().As<ISpartan_Token_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Transaction_LogService>().As<ISpartan_Transaction_LogService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Transition_Event_TypeService>().As<ISpartan_Transition_Event_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Transition_Log_TypeService>().As<ISpartan_Transition_Log_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Alert_StatusService>().As<ISpartan_User_Alert_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Alert_TypeService>().As<ISpartan_User_Alert_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_AlertService>().As<ISpartan_User_AlertService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Favorite_ListService>().As<ISpartan_User_Favorite_ListService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Favorite_ObjectService>().As<ISpartan_User_Favorite_ObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Most_Used_ObjectService>().As<ISpartan_User_Most_Used_ObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Object_Method_ConfigService>().As<ISpartan_User_Object_Method_ConfigService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_QuicklinkService>().As<ISpartan_User_QuicklinkService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Role_StatusService>().As<ISpartan_User_Role_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_RoleService>().As<ISpartan_User_RoleService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Rule_Module_ObjectService>().As<ISpartan_User_Rule_Module_ObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Rule_ModuleService>().As<ISpartan_User_Rule_ModuleService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Rule_Object_FunctionService>().As<ISpartan_User_Rule_Object_FunctionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_StatusService>().As<ISpartan_User_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_UserService>().As<ISpartan_UserService>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepository<>));
            builder.RegisterType<TTUsuariosService>().As<ITTUsuariosService>().InstancePerLifetimeScope();
            builder.RegisterType<CustomAuthenticationService>().As<ICustomAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_QueryService>().As<ISpartan_QueryService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Attribute_Control_TypeService>().As<ISpartan_Attribute_Control_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Business_RuleService>().As<ISpartan_Business_RuleService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ActionService>().As<ISpartan_BR_ActionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Attribute_Restrictions_DetailService>().As<ISpartan_BR_Attribute_Restrictions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_ClassificationService>().As<ISpartan_BR_Action_ClassificationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_Configuration_DetailService>().As<ISpartan_BR_Action_Configuration_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Event_Restrictions_DetailService>().As<ISpartan_BR_Event_Restrictions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Actions_False_DetailService>().As<ISpartan_BR_Actions_False_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operation_Restrictions_DetailService>().As<ISpartan_BR_Operation_Restrictions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_Param_TypeService>().As<ISpartan_BR_Action_Param_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_ResultService>().As<ISpartan_BR_Action_ResultService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Actions_True_DetailService>().As<ISpartan_BR_Actions_True_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ConditionService>().As<ISpartan_BR_ConditionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Condition_OperatorService>().As<ISpartan_BR_Condition_OperatorService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Conditions_DetailService>().As<ISpartan_BR_Conditions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_OperationService>().As<ISpartan_BR_OperationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operation_DetailService>().As<ISpartan_BR_Operation_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operator_TypeService>().As<ISpartan_BR_Operator_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Presentation_Control_TypeService>().As<ISpartan_BR_Presentation_Control_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Process_EventService>().As<ISpartan_BR_Process_EventService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Process_Event_DetailService>().As<ISpartan_BR_Process_Event_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ScopeService>().As<ISpartan_BR_ScopeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Scope_DetailService>().As<ISpartan_BR_Scope_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_StatusService>().As<ISpartan_BR_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Modifications_LogService>().As<ISpartan_BR_Modifications_LogService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_MetadataService>().As<ISpartan_MetadataService>().InstancePerLifetimeScope();

            builder.RegisterType<Spartan_Report_Permission_TypeService>().As<ISpartan_Report_Permission_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_PermissionsService>().As<ISpartan_Report_PermissionsService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_ReportService>().As<ISpartan_ReportService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_Presentation_TypeService>().As<ISpartan_Report_Presentation_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_Presentation_ViewService>().As<ISpartan_Report_Presentation_ViewService>().InstancePerLifetimeScope();
			builder.RegisterType<Spartan_Report_Field_TypeService>().As<ISpartan_Report_Field_TypeService>().InstancePerLifetimeScope();
			builder.RegisterType<Spartan_Report_Fields_DetailService>().As<ISpartan_Report_Fields_DetailService>().InstancePerLifetimeScope();
			builder.RegisterType<Spartan_Report_FormatService>().As<ISpartan_Report_FormatService>().InstancePerLifetimeScope();
			builder.RegisterType<Spartan_Report_FunctionService>().As<ISpartan_Report_FunctionService>().InstancePerLifetimeScope();
			builder.RegisterType<Spartan_Report_Order_TypeService>().As<ISpartan_Report_Order_TypeService>().InstancePerLifetimeScope();
			builder.RegisterType<Spartan_Report_StatusService>().As<ISpartan_Report_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartane.Services.Spartan_Additional_Menu.Spartan_Additional_Menu>().As<ISpartan_Additional_Menu>().InstancePerLifetimeScope();
			builder.RegisterType<GeneratePDFService>().As<IGeneratePDFService>().InstancePerLifetimeScope();

            builder.RegisterType<Spartan_Traduction_Concept_TypeService>().As<ISpartan_Traduction_Concept_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_DetailService>().As<ISpartan_Traduction_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_LanguageService>().As<ISpartan_Traduction_LanguageService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_ObjectService>().As<ISpartan_Traduction_ObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Object_TypeService>().As<ISpartan_Traduction_Object_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_ProcessService>().As<ISpartan_Traduction_ProcessService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Process_DataService>().As<ISpartan_Traduction_Process_DataService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Process_WorkflowService>().As<ISpartan_Traduction_Process_WorkflowService>().InstancePerLifetimeScope();
            
            builder.RegisterType<Spartan_WorkFlowService>().As<ISpartan_WorkFlowService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_ConditionService>().As<ISpartan_WorkFlow_ConditionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Condition_OperatorService>().As<ISpartan_WorkFlow_Condition_OperatorService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Conditions_by_StateService>().As<ISpartan_WorkFlow_Conditions_by_StateService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Information_by_StateService>().As<ISpartan_WorkFlow_Information_by_StateService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Matrix_of_StatesService>().As<ISpartan_WorkFlow_Matrix_of_StatesService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_OperatorService>().As<ISpartan_WorkFlow_OperatorService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Phase_StatusService>().As<ISpartan_WorkFlow_Phase_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Phase_TypeService>().As<ISpartan_WorkFlow_Phase_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_PhasesService>().As<ISpartan_WorkFlow_PhasesService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Roles_by_StateService>().As<ISpartan_WorkFlow_Roles_by_StateService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_StateService>().As<ISpartan_WorkFlow_StateService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_StatusService>().As<ISpartan_WorkFlow_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Type_Flow_ControlService>().As<ISpartan_WorkFlow_Type_Flow_ControlService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Type_Work_DistributionService>().As<ISpartan_WorkFlow_Type_Work_DistributionService>().InstancePerLifetimeScope();

            builder.RegisterType<SpartanObjectService>().As<ISpartanObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_FilterService>().As<ISpartan_Report_FilterService>().InstancePerLifetimeScope();
			builder.RegisterType<SpartanChangePasswordAutorizationEstatusService>().As<ISpartanChangePasswordAutorizationEstatusService>().InstancePerLifetimeScope();
			builder.RegisterType<Spartan_ChangePasswordAutorizationService>().As<ISpartan_ChangePasswordAutorizationService>().InstancePerLifetimeScope();
			builder.RegisterType<Spartan_User_Historical_PasswordService>().As<ISpartan_User_Historical_PasswordService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_SettingsService>().As<ISpartan_SettingsService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Report_Advance_FilterService>().As<ISpartan_Report_Advance_FilterService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Format_RelatedService>().As<ISpartan_Format_RelatedService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Bitacora_SQLService>().As<ISpartan_Bitacora_SQLService>().InstancePerLifetimeScope();
            builder.RegisterType<Business_Rule_CreationService>().As<IBusiness_Rule_CreationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ComplexityService>().As<ISpartan_BR_ComplexityService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Peer_ReviewService>().As<ISpartan_BR_Peer_ReviewService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Rejection_ReasonService>().As<ISpartan_BR_Rejection_ReasonService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_TestingService>().As<ISpartan_BR_TestingService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_HistoryService>().As<ISpartan_BR_HistoryService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Type_HistoryService>().As<ISpartan_BR_Type_HistoryService>().InstancePerLifetimeScope();
            builder.RegisterType<Template_Dashboard_EditorService>().As<ITemplate_Dashboard_EditorService>().InstancePerLifetimeScope();
            builder.RegisterType<Dashboard_StatusService>().As<IDashboard_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Dashboard_EditorService>().As<IDashboard_EditorService>().InstancePerLifetimeScope();
            builder.RegisterType<Template_Dashboard_DetailService>().As<ITemplate_Dashboard_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Dashboard_Config_DetailService>().As<IDashboard_Config_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Antiguedad_EjerciciosService>().As<IAntiguedad_EjerciciosService>().InstancePerLifetimeScope();
builder.RegisterType<BebidasService>().As<IBebidasService>().InstancePerLifetimeScope();
builder.RegisterType<CaloriasService>().As<ICaloriasService>().InstancePerLifetimeScope();
builder.RegisterType<Cantidad_ComidasService>().As<ICantidad_ComidasService>().InstancePerLifetimeScope();
builder.RegisterType<Categorias_de_platillosService>().As<ICategorias_de_platillosService>().InstancePerLifetimeScope();
builder.RegisterType<Clasificacion_IngredientesService>().As<IClasificacion_IngredientesService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Antecedentes_FamiliaresService>().As<IDetalle_Antecedentes_FamiliaresService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Antecedentes_No_PatologicosService>().As<IDetalle_Antecedentes_No_PatologicosService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_de_IngredientesService>().As<IDetalle_de_IngredientesService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_de_PadecimientosService>().As<IDetalle_de_PadecimientosService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Examenes_LaboratorioService>().As<IDetalle_Examenes_LaboratorioService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Preferencia_BebidasService>().As<IDetalle_Preferencia_BebidasService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Terapia_HormonalService>().As<IDetalle_Terapia_HormonalService>().InstancePerLifetimeScope();
builder.RegisterType<Dias_de_la_semanaService>().As<IDias_de_la_semanaService>().InstancePerLifetimeScope();
builder.RegisterType<Dificultad_de_platillosService>().As<IDificultad_de_platillosService>().InstancePerLifetimeScope();
builder.RegisterType<Duracion_EjercicioService>().As<IDuracion_EjercicioService>().InstancePerLifetimeScope();
builder.RegisterType<EjerciciosService>().As<IEjerciciosService>().InstancePerLifetimeScope();
builder.RegisterType<EmpresasService>().As<IEmpresasService>().InstancePerLifetimeScope();
builder.RegisterType<EnfermedadesService>().As<IEnfermedadesService>().InstancePerLifetimeScope();
builder.RegisterType<EstadoService>().As<IEstadoService>().InstancePerLifetimeScope();
builder.RegisterType<Estado_CivilService>().As<IEstado_CivilService>().InstancePerLifetimeScope();
builder.RegisterType<Estado_de_AnimoService>().As<IEstado_de_AnimoService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_PacienteService>().As<IEstatus_PacienteService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_PadecimientoService>().As<IEstatus_PadecimientoService>().InstancePerLifetimeScope();
builder.RegisterType<Frecuencia_EjercicioService>().As<IFrecuencia_EjercicioService>().InstancePerLifetimeScope();
builder.RegisterType<Frecuencia_SustanciasService>().As<IFrecuencia_SustanciasService>().InstancePerLifetimeScope();
builder.RegisterType<Indicadores_LaboratorioService>().As<IIndicadores_LaboratorioService>().InstancePerLifetimeScope();
builder.RegisterType<IngredientesService>().As<IIngredientesService>().InstancePerLifetimeScope();
builder.RegisterType<MarcaService>().As<IMarcaService>().InstancePerLifetimeScope();
builder.RegisterType<MedicosService>().As<IMedicosService>().InstancePerLifetimeScope();
builder.RegisterType<Nivel_de_SatisfaccionService>().As<INivel_de_SatisfaccionService>().InstancePerLifetimeScope();
builder.RegisterType<ObjetivosService>().As<IObjetivosService>().InstancePerLifetimeScope();
builder.RegisterType<PacientesService>().As<IPacientesService>().InstancePerLifetimeScope();
builder.RegisterType<PadecimientosService>().As<IPadecimientosService>().InstancePerLifetimeScope();
builder.RegisterType<PaisService>().As<IPaisService>().InstancePerLifetimeScope();
builder.RegisterType<ParentescoService>().As<IParentescoService>().InstancePerLifetimeScope();
builder.RegisterType<Periodo_del_diaService>().As<IPeriodo_del_diaService>().InstancePerLifetimeScope();
builder.RegisterType<PlatillosService>().As<IPlatillosService>().InstancePerLifetimeScope();
builder.RegisterType<Preferencias_EntrecomidasService>().As<IPreferencias_EntrecomidasService>().InstancePerLifetimeScope();
builder.RegisterType<Preferencias_GrasasService>().As<IPreferencias_GrasasService>().InstancePerLifetimeScope();
builder.RegisterType<Preferencias_PreparacionService>().As<IPreferencias_PreparacionService>().InstancePerLifetimeScope();
builder.RegisterType<Preferencias_SalService>().As<IPreferencias_SalService>().InstancePerLifetimeScope();
builder.RegisterType<PresentacionService>().As<IPresentacionService>().InstancePerLifetimeScope();
builder.RegisterType<Rango_Consumo_BebidasService>().As<IRango_Consumo_BebidasService>().InstancePerLifetimeScope();
builder.RegisterType<Rango_de_HorasService>().As<IRango_de_HorasService>().InstancePerLifetimeScope();
builder.RegisterType<RegistroService>().As<IRegistroService>().InstancePerLifetimeScope();
builder.RegisterType<Respuesta_LogicaService>().As<IRespuesta_LogicaService>().InstancePerLifetimeScope();
builder.RegisterType<Resultados_IMCService>().As<IResultados_IMCService>().InstancePerLifetimeScope();
builder.RegisterType<Seleccion_de_RangosService>().As<ISeleccion_de_RangosService>().InstancePerLifetimeScope();
builder.RegisterType<SexoService>().As<ISexoService>().InstancePerLifetimeScope();
builder.RegisterType<SuplementosService>().As<ISuplementosService>().InstancePerLifetimeScope();
builder.RegisterType<SustanciasService>().As<ISustanciasService>().InstancePerLifetimeScope();
builder.RegisterType<Tiempo_PadecimientoService>().As<ITiempo_PadecimientoService>().InstancePerLifetimeScope();
builder.RegisterType<Tiempos_de_ComidaService>().As<ITiempos_de_ComidaService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_DietaService>().As<ITipo_de_DietaService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_RegistroService>().As<ITipo_de_RegistroService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_EjercicioService>().As<ITipo_EjercicioService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_Modificacion_AlimentosService>().As<ITipo_Modificacion_AlimentosService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_PacienteService>().As<ITipo_PacienteService>().InstancePerLifetimeScope();
builder.RegisterType<Unidades_de_MedidaService>().As<IUnidades_de_MedidaService>().InstancePerLifetimeScope();
builder.RegisterType<ConsultasService>().As<IConsultasService>().InstancePerLifetimeScope();
builder.RegisterType<EstatusService>().As<IEstatusService>().InstancePerLifetimeScope();
builder.RegisterType<ProfesionesService>().As<IProfesionesService>().InstancePerLifetimeScope();
builder.RegisterType<EspecialidadesService>().As<IEspecialidadesService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Identificacion_Oficial_MedicosService>().As<IDetalle_Identificacion_Oficial_MedicosService>().InstancePerLifetimeScope();
builder.RegisterType<Identificaciones_OficialesService>().As<IIdentificaciones_OficialesService>().InstancePerLifetimeScope();
builder.RegisterType<Regimenes_FiscalesService>().As<IRegimenes_FiscalesService>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_de_porcentaje_de_grasa_corporalService>().As<IInterpretacion_de_porcentaje_de_grasa_corporalService>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_IMCService>().As<IInterpretacion_IMCService>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_corporalService>().As<IInterpretacion_corporalService>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_distribucion_grasa_corporalService>().As<IInterpretacion_distribucion_grasa_corporalService>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_indice_cintura__caderaService>().As<IInterpretacion_indice_cintura__caderaService>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_consumo_de_aguaService>().As<IInterpretacion_consumo_de_aguaService>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_Frecuencia_cardiaca_en_EsfuerzoService>().As<IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoService>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_Dificultad_de_Rutina_de_EjerciciosService>().As<IInterpretacion_Dificultad_de_Rutina_de_EjerciciosService>().InstancePerLifetimeScope();
builder.RegisterType<Interpretacion_CaloriasService>().As<IInterpretacion_CaloriasService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_Plan_de_SuscripcionService>().As<ITipo_de_Plan_de_SuscripcionService>().InstancePerLifetimeScope();
builder.RegisterType<Duracion_de_Planes_de_SuscripcionService>().As<IDuracion_de_Planes_de_SuscripcionService>().InstancePerLifetimeScope();
builder.RegisterType<Planes_de_SuscripcionService>().As<IPlanes_de_SuscripcionService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_por_SuscripcionService>().As<IEstatus_por_SuscripcionService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Suscripciones_PacienteService>().As<IDetalle_Suscripciones_PacienteService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Pagos_PacienteService>().As<IDetalle_Pagos_PacienteService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_de_SuscripcionService>().As<IEstatus_de_SuscripcionService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_de_PagoService>().As<IEstatus_de_PagoService>().InstancePerLifetimeScope();
builder.RegisterType<Formas_de_PagoService>().As<IFormas_de_PagoService>().InstancePerLifetimeScope();
builder.RegisterType<Frecuencia_de_pago_PacientesService>().As<IFrecuencia_de_pago_PacientesService>().InstancePerLifetimeScope();
builder.RegisterType<Frecuencia_de_pago_EmpresasService>().As<IFrecuencia_de_pago_EmpresasService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Resultados_ConsultasService>().As<IDetalle_Resultados_ConsultasService>().InstancePerLifetimeScope();
builder.RegisterType<Indicadores_ConsultasService>().As<IIndicadores_ConsultasService>().InstancePerLifetimeScope();
builder.RegisterType<Tipos_de_EspecialistasService>().As<ITipos_de_EspecialistasService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Titulos_MedicosService>().As<IDetalle_Titulos_MedicosService>().InstancePerLifetimeScope();
builder.RegisterType<areas_EmpresasService>().As<Iareas_EmpresasService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Suscripciones_EmpresaService>().As<IDetalle_Suscripciones_EmpresaService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Pagos_EmpresaService>().As<IDetalle_Pagos_EmpresaService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Contactos_EmpresaService>().As<IDetalle_Contactos_EmpresaService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Contratos_EmpresaService>().As<IDetalle_Contratos_EmpresaService>().InstancePerLifetimeScope();
builder.RegisterType<Tipos_de_ContratoService>().As<ITipos_de_ContratoService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Codigos_ReferidosService>().As<IDetalle_Codigos_ReferidosService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Convenio_Medicos_AseguradorasService>().As<IDetalle_Convenio_Medicos_AseguradorasService>().InstancePerLifetimeScope();
builder.RegisterType<AseguradorasService>().As<IAseguradorasService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Planes_de_Suscripcion_EspecialistasService>().As<IDetalle_Planes_de_Suscripcion_EspecialistasService>().InstancePerLifetimeScope();
builder.RegisterType<Datos_Bancarios_EspecialistasService>().As<IDatos_Bancarios_EspecialistasService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Pagos_EspecialistasService>().As<IDetalle_Pagos_EspecialistasService>().InstancePerLifetimeScope();
builder.RegisterType<Planes_de_Suscripcion_EspecialistasService>().As<IPlanes_de_Suscripcion_EspecialistasService>().InstancePerLifetimeScope();
builder.RegisterType<Frecuencia_de_pago_EspecialistasService>().As<IFrecuencia_de_pago_EspecialistasService>().InstancePerLifetimeScope();
builder.RegisterType<BancosService>().As<IBancosService>().InstancePerLifetimeScope();
builder.RegisterType<EventosService>().As<IEventosService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Actividades_EventoService>().As<IDetalle_Actividades_EventoService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_Actividades_EventoService>().As<IEstatus_Actividades_EventoService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_Reservaciones_ActividadService>().As<IEstatus_Reservaciones_ActividadService>().InstancePerLifetimeScope();
builder.RegisterType<Tipos_de_ActividadesService>().As<ITipos_de_ActividadesService>().InstancePerLifetimeScope();
builder.RegisterType<Ubicaciones_Eventos_EmpresaService>().As<IUbicaciones_Eventos_EmpresaService>().InstancePerLifetimeScope();
builder.RegisterType<Actividades_del_EventoService>().As<IActividades_del_EventoService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Horarios_ActividadService>().As<IDetalle_Horarios_ActividadService>().InstancePerLifetimeScope();
builder.RegisterType<Parentescos_EmpleadosService>().As<IParentescos_EmpleadosService>().InstancePerLifetimeScope();
builder.RegisterType<Registro_en_EventoService>().As<IRegistro_en_EventoService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Consulta_Actividades_Registro_EventoService>().As<IDetalle_Consulta_Actividades_Registro_EventoService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Registro_en_Actividad_EventoService>().As<IDetalle_Registro_en_Actividad_EventoService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_EventosService>().As<IEstatus_EventosService>().InstancePerLifetimeScope();
builder.RegisterType<MS_Exclusion_Ingredientes_PacienteService>().As<IMS_Exclusion_Ingredientes_PacienteService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Especialistas_PacientesService>().As<IDetalle_Especialistas_PacientesService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Facturacion_EspecialistasService>().As<IDetalle_Facturacion_EspecialistasService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_FacturasService>().As<IEstatus_FacturasService>().InstancePerLifetimeScope();
builder.RegisterType<Titulos_PersonalesService>().As<ITitulos_PersonalesService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Redes_Sociales_EspecialistaService>().As<IDetalle_Redes_Sociales_EspecialistaService>().InstancePerLifetimeScope();
builder.RegisterType<Redes_socialesService>().As<IRedes_socialesService>().InstancePerLifetimeScope();
builder.RegisterType<MS_Suscripciones_Codigos_Referidos_EspecialistaService>().As<IMS_Suscripciones_Codigos_Referidos_EspecialistaService>().InstancePerLifetimeScope();
builder.RegisterType<MotivosService>().As<IMotivosService>().InstancePerLifetimeScope();
builder.RegisterType<Solicitud_de_Cita_con_EspecialistaService>().As<ISolicitud_de_Cita_con_EspecialistaService>().InstancePerLifetimeScope();
builder.RegisterType<CalificacionService>().As<ICalificacionService>().InstancePerLifetimeScope();
builder.RegisterType<Asuntos_Asistencia_TelefonicaService>().As<IAsuntos_Asistencia_TelefonicaService>().InstancePerLifetimeScope();
builder.RegisterType<Estatus_LlamadasService>().As<IEstatus_LlamadasService>().InstancePerLifetimeScope();
builder.RegisterType<Registro_de_Asistencia_TelefonicaService>().As<IRegistro_de_Asistencia_TelefonicaService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Registro_Beneficiarios_EmpresaService>().As<IDetalle_Registro_Beneficiarios_EmpresaService>().InstancePerLifetimeScope();
builder.RegisterType<Tipos_de_EmpresaService>().As<ITipos_de_EmpresaService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Caracteristicas_IngredienteService>().As<IDetalle_Caracteristicas_IngredienteService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_comida_platillosService>().As<ITipo_de_comida_platillosService>().InstancePerLifetimeScope();
builder.RegisterType<Caracteristicas_platilloService>().As<ICaracteristicas_platilloService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_PlatillosService>().As<IDetalle_PlatillosService>().InstancePerLifetimeScope();
builder.RegisterType<Cantidad_fraccion_platillosService>().As<ICantidad_fraccion_platillosService>().InstancePerLifetimeScope();
builder.RegisterType<Pantalla_FranciscoService>().As<IPantalla_FranciscoService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_pantalla_FranciscoService>().As<IDetalle_pantalla_FranciscoService>().InstancePerLifetimeScope();
builder.RegisterType<Tips_y_PromocionesService>().As<ITips_y_PromocionesService>().InstancePerLifetimeScope();
builder.RegisterType<Planes_AlimenticiosService>().As<IPlanes_AlimenticiosService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Planes_AlimenticiosService>().As<IDetalle_Planes_AlimenticiosService>().InstancePerLifetimeScope();
builder.RegisterType<Planes_de_RutinasService>().As<IPlanes_de_RutinasService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Planes_de_RutinasService>().As<IDetalle_Planes_de_RutinasService>().InstancePerLifetimeScope();
builder.RegisterType<RutinasService>().As<IRutinasService>().InstancePerLifetimeScope();
builder.RegisterType<Nivel_de_dificultadService>().As<INivel_de_dificultadService>().InstancePerLifetimeScope();
builder.RegisterType<Nivel_de_IntensidadService>().As<INivel_de_IntensidadService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Ejercicios_RutinasService>().As<IDetalle_Ejercicios_RutinasService>().InstancePerLifetimeScope();
builder.RegisterType<MusculosService>().As<IMusculosService>().InstancePerLifetimeScope();
builder.RegisterType<Equipamiento_para_EjerciciosService>().As<IEquipamiento_para_EjerciciosService>().InstancePerLifetimeScope();
builder.RegisterType<MS_MusculosService>().As<IMS_MusculosService>().InstancePerLifetimeScope();
builder.RegisterType<MS_Equipamiento_para_EjerciciosService>().As<IMS_Equipamiento_para_EjerciciosService>().InstancePerLifetimeScope();
builder.RegisterType<VendedoresService>().As<IVendedoresService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Codigos_de_Referencia_VendedoresService>().As<IDetalle_Codigos_de_Referencia_VendedoresService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Facturacion_VendedoresService>().As<IDetalle_Facturacion_VendedoresService>().InstancePerLifetimeScope();
builder.RegisterType<ProveedoresService>().As<IProveedoresService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_proveedorService>().As<ITipo_de_proveedorService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Sucursales_ProveedoresService>().As<IDetalle_Sucursales_ProveedoresService>().InstancePerLifetimeScope();
builder.RegisterType<Tipo_de_SucursalService>().As<ITipo_de_SucursalService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Suscripcion_Red_de_Especialistas_ProveedoresService>().As<IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresService>().InstancePerLifetimeScope();
builder.RegisterType<Planes_de_Suscripcion_ProveedoresService>().As<IPlanes_de_Suscripcion_ProveedoresService>().InstancePerLifetimeScope();
//**@@INCLUDE_EXPOSE@@**//
            GlobalConfiguration.Configuration.EnsureInitialized();

            //// Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            //// Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //// OPTIONAL: Register the Autofac filter provider.
            //builder.RegisterWebApiFilterProvider(config);

            //// Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


        }
    }
}





























































































































































































































































































































































































































































































































































