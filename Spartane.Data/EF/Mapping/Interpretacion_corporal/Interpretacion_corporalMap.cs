using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Interpretacion_corporal
{
    public partial class Interpretacion_corporalMap : EntityTypeConfiguration<Spartane.Core.Classes.Interpretacion_corporal.Interpretacion_corporal>
    {
        public Interpretacion_corporalMap()
        {
            this.ToTable("Interpretacion_corporal");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
