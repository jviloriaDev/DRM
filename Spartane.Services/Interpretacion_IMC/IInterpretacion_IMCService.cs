using System;
using Spartane.Core.Classes.Interpretacion_IMC;
using System.Collections.Generic;


namespace Spartane.Services.Interpretacion_IMC
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IInterpretacion_IMCService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Interpretacion_IMC.Interpretacion_IMC> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Interpretacion_IMC.Interpretacion_IMC> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Interpretacion_IMC.Interpretacion_IMC> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Interpretacion_IMC.Interpretacion_IMC GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Interpretacion_IMC.Interpretacion_IMC entity);
        Int32 Update(Spartane.Core.Classes.Interpretacion_IMC.Interpretacion_IMC entity);
        IList<Spartane.Core.Classes.Interpretacion_IMC.Interpretacion_IMC> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Interpretacion_IMC.Interpretacion_IMC> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Interpretacion_IMC.Interpretacion_IMCPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Interpretacion_IMC.Interpretacion_IMC> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Interpretacion_IMC.Interpretacion_IMC entity);

    }
}
