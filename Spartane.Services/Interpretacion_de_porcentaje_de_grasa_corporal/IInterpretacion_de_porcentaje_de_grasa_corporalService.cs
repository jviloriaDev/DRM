using System;
using Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal;
using System.Collections.Generic;


namespace Spartane.Services.Interpretacion_de_porcentaje_de_grasa_corporal
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IInterpretacion_de_porcentaje_de_grasa_corporalService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal entity);
        Int32 Update(Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal entity);
        IList<Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporalPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal entity);

    }
}
