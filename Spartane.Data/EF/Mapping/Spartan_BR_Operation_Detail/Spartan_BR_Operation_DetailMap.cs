using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Operation_Detail
{
    public partial class Spartan_BR_Operation_DetailMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Operation_Detail.Spartan_BR_Operation_Detail>
    {
        public Spartan_BR_Operation_DetailMap()
        {
            this.ToTable("Spartan_BR_Operation_Detail");
            this.HasKey(a => a.OperationDetailId);
            this.Ignore(a => a.Id);
        }
    }
}
