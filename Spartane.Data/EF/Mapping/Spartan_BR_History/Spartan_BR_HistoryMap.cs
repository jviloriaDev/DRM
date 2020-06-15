using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_History
{
    public partial class Spartan_BR_HistoryMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_History.Spartan_BR_History>
    {
        public Spartan_BR_HistoryMap()
        {
            this.ToTable("Spartan_BR_History");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Key_History);
        }
    }
}
