using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Interpretacion_distribucion_grasa_corporal
{
    public partial class Interpretacion_distribucion_grasa_corporalMap : EntityTypeConfiguration<Spartane.Core.Classes.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal>
    {
        public Interpretacion_distribucion_grasa_corporalMap()
        {
            this.ToTable("Interpretacion_distribucion_grasa_corporal");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
