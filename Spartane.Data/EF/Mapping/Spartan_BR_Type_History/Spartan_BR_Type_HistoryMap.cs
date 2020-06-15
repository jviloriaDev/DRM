using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Type_History
{
    public partial class Spartan_BR_Type_HistoryMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Type_History.Spartan_BR_Type_History>
    {
        public Spartan_BR_Type_HistoryMap()
        {
            this.ToTable("Spartan_BR_Type_History");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Key_Type_History);
        }
    }
}
