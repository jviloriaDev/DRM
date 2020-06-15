using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Bancos
{
    public partial class BancosMap : EntityTypeConfiguration<Spartane.Core.Classes.Bancos.Bancos>
    {
        public BancosMap()
        {
            this.ToTable("Bancos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
