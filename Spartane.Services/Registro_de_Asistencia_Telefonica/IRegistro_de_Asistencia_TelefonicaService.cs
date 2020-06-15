using System;
using Spartane.Core.Classes.Registro_de_Asistencia_Telefonica;
using System.Collections.Generic;


namespace Spartane.Services.Registro_de_Asistencia_Telefonica
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRegistro_de_Asistencia_TelefonicaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica entity);
        Int32 Update(Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica entity);
        IList<Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_TelefonicaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Registro_de_Asistencia_Telefonica.Registro_de_Asistencia_Telefonica entity);

    }
}
