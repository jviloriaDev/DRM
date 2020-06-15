using System;
using Spartane.Core.Classes.Medicos;
using System.Collections.Generic;


namespace Spartane.Services.Medicos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMedicosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Medicos.Medicos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Medicos.Medicos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Medicos.Medicos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Medicos.Medicos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Medicos.Medicos entity);
        Int32 Update(Spartane.Core.Classes.Medicos.Medicos entity);
        IList<Spartane.Core.Classes.Medicos.Medicos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Medicos.Medicos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Medicos.MedicosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Medicos.Medicos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Medicos.Medicos entity);
       int Update_Datos_de_Contacto(Spartane.Core.Classes.Medicos.Medicos entity);
       int Update_Datos_Profesionales(Spartane.Core.Classes.Medicos.Medicos entity);
       int Update_Datos_Fiscales(Spartane.Core.Classes.Medicos.Medicos entity);
       int Update_Documentacion(Spartane.Core.Classes.Medicos.Medicos entity);
       int Update_Codigos_de_Referencia(Spartane.Core.Classes.Medicos.Medicos entity);
       int Update_Suscripcion_Red_de_Especialistas(Spartane.Core.Classes.Medicos.Medicos entity);
       int Update_Datos_Bancarios(Spartane.Core.Classes.Medicos.Medicos entity);
       int Update_Facturacion(Spartane.Core.Classes.Medicos.Medicos entity);

    }
}
