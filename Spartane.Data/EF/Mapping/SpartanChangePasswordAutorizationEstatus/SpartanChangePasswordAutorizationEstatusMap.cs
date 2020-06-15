using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.SpartanChangePasswordAutorizationEstatus
{
    public partial class SpartanChangePasswordAutorizationEstatusMap : EntityTypeConfiguration<Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>
    {
        public SpartanChangePasswordAutorizationEstatusMap()
        {
            this.ToTable("SpartanChangePasswordAutorizationEstatus");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
