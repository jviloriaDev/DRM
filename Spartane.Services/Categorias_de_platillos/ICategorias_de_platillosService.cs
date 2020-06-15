using System;
using Spartane.Core.Classes.Categorias_de_platillos;
using System.Collections.Generic;


namespace Spartane.Services.Categorias_de_platillos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ICategorias_de_platillosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos entity);
        Int32 Update(Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos entity);
        IList<Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos entity);

    }
}
