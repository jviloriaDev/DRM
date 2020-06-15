using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_ChangePasswordAutorization
{
    public partial class Spartan_ChangePasswordAutorizationMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>
    {
        public Spartan_ChangePasswordAutorizationMap()
        {
            this.ToTable("Spartan_ChangePasswordAutorization");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
