using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Peer_Review
{
    public partial class Spartan_BR_Peer_ReviewMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Peer_Review.Spartan_BR_Peer_Review>
    {
        public Spartan_BR_Peer_ReviewMap()
        {
            this.ToTable("Spartan_BR_Peer_Review");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Key_Peer_Review);
        }
    }
}
