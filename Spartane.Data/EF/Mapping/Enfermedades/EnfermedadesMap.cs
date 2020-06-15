using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Enfermedades
{
    public partial class EnfermedadesMap : EntityTypeConfiguration<Spartane.Core.Classes.Enfermedades.Enfermedades>
    {
        public EnfermedadesMap()
        {
            this.ToTable("Enfermedades");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
