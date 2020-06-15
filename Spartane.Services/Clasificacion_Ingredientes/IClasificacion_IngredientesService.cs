using System;
using Spartane.Core.Classes.Clasificacion_Ingredientes;
using System.Collections.Generic;


namespace Spartane.Services.Clasificacion_Ingredientes
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IClasificacion_IngredientesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes entity);
        Int32 Update(Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes entity);
        IList<Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_IngredientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes entity);

    }
}
