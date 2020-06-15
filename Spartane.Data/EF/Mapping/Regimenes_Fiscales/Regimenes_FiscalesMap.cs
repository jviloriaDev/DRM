using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Regimenes_Fiscales
{
    public partial class Regimenes_FiscalesMap : EntityTypeConfiguration<Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales>
    {
        public Regimenes_FiscalesMap()
        {
            this.ToTable("Regimenes_Fiscales");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
