using System;
using Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Caracteristicas_Ingrediente
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Caracteristicas_IngredienteService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente entity);
        IList<Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_IngredientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente entity);

    }
}
