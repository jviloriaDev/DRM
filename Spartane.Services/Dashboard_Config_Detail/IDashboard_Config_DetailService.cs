using System;
using Spartane.Core.Classes.Dashboard_Config_Detail;
using System.Collections.Generic;


namespace Spartane.Services.Dashboard_Config_Detail
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDashboard_Config_DetailService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail entity);
        Int32 Update(Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail entity);
        IList<Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_DetailPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Dashboard_Config_Detail.Dashboard_Config_Detail entity);

    }
}
