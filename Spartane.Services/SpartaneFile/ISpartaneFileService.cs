using System;
//using Spartane.Core.Domain.Departamento;
using System.Collections.Generic;
//using Spartane.Core.Domain.Data;

namespace Spartane.Services.SpartaneFile
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartaneFileService
    {
        Int64 Insert(Spartane.Core.Classes.SpartaneFile.SpartaneFile entity);
        Spartane.Core.Classes.SpartaneFile.SpartaneFile GetByKey(long? Key, Boolean ConRelaciones);
        bool Delete(long? Key);
        Int64 Update(Spartane.Core.Classes.SpartaneFile.SpartaneFile entity);
    }
}

