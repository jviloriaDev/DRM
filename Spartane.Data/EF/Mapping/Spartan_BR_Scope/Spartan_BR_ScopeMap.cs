using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Scope
{
    public partial class Spartan_BR_ScopeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Scope.Spartan_BR_Scope>
    {
        public Spartan_BR_ScopeMap()
        {
            this.ToTable("Spartan_BR_Scope");
            this.HasKey(a => a.ScopeId);
            this.Ignore(a => a.Id);
        }
    }
}
