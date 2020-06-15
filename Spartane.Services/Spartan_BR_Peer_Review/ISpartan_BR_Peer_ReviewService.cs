using System;
using Spartane.Core.Classes.Spartan_BR_Peer_Review;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_BR_Peer_Review
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_Peer_ReviewService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review entity);
        Int32 Update(Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review entity);
        IList<Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_ReviewPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
