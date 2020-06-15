using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Profesiones
{
    public partial class ProfesionesMap : EntityTypeConfiguration<Spartane.Core.Classes.Profesiones.Profesiones>
    {
        public ProfesionesMap()
        {
            this.ToTable("Profesiones");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
