using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Operation
{
    public partial class Spartan_BR_OperationMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Operation.Spartan_BR_Operation>
    {
        public Spartan_BR_OperationMap()
        {
            this.ToTable("Spartan_BR_Operation");
            this.HasKey(a => a.OperationId);
            this.Ignore(a => a.Id);
        }
    }
}
