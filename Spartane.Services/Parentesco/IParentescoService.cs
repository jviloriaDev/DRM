﻿using System;
using Spartane.Core.Classes.Parentesco;
using System.Collections.Generic;


namespace Spartane.Services.Parentesco
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IParentescoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Parentesco.Parentesco> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Parentesco.Parentesco> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Parentesco.Parentesco> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Parentesco.Parentesco GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Parentesco.Parentesco entity);
        Int32 Update(Spartane.Core.Classes.Parentesco.Parentesco entity);
        IList<Spartane.Core.Classes.Parentesco.Parentesco> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Parentesco.Parentesco> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Parentesco.ParentescoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Parentesco.Parentesco> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Parentesco.Parentesco entity);

    }
}
