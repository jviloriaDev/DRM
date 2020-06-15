using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Identificaciones_Oficiales
{
    public partial class Identificaciones_OficialesMap : EntityTypeConfiguration<Spartane.Core.Classes.Identificaciones_Oficiales.Identificaciones_Oficiales>
    {
        public Identificaciones_OficialesMap()
        {
            this.ToTable("Identificaciones_Oficiales");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
