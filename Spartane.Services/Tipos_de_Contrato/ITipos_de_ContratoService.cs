using System;
using Spartane.Core.Classes.Tipos_de_Contrato;
using System.Collections.Generic;


namespace Spartane.Services.Tipos_de_Contrato
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipos_de_ContratoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato entity);
        Int32 Update(Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato entity);
        IList<Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_ContratoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Tipos_de_Contrato.Tipos_de_Contrato entity);

    }
}
