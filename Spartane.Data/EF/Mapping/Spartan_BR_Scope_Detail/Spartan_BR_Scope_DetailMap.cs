using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Scope_Detail
{
    public partial class Spartan_BR_Scope_DetailMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Scope_Detail.Spartan_BR_Scope_Detail>
    {
        public Spartan_BR_Scope_DetailMap()
        {
            this.ToTable("Spartan_BR_Scope_Detail");
            this.HasKey(a => a.ScopeDetailId);
            this.Ignore(a => a.Id);
        }
    }
}
