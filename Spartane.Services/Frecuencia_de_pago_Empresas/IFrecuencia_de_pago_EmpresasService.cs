using System;
using Spartane.Core.Classes.Frecuencia_de_pago_Empresas;
using System.Collections.Generic;


namespace Spartane.Services.Frecuencia_de_pago_Empresas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IFrecuencia_de_pago_EmpresasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas entity);
        Int32 Update(Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas entity);
        IList<Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_EmpresasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas entity);

    }
}
