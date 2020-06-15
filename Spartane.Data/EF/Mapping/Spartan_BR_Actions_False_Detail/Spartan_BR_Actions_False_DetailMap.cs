using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Actions_False_Detail
{
    public partial class Spartan_BR_Actions_False_DetailMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Actions_False_Detail.Spartan_BR_Actions_False_Detail>
    {
        public Spartan_BR_Actions_False_DetailMap()
        {
            this.ToTable("Spartan_BR_Actions_False_Detail");
            this.HasKey(a => a.ActionsFalseDetailId);
            this.Ignore(a => a.Id);
        }
    }
}
