using System;
using Spartane.Core.Classes.Periodo_del_dia;
using System.Collections.Generic;


namespace Spartane.Services.Periodo_del_dia
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPeriodo_del_diaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia entity);
        Int32 Update(Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia entity);
        IList<Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Periodo_del_dia.Periodo_del_diaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia entity);

    }
}
