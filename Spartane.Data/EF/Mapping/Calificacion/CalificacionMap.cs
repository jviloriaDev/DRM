using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Calificacion
{
    public partial class CalificacionMap : EntityTypeConfiguration<Spartane.Core.Classes.Calificacion.Calificacion>
    {
        public CalificacionMap()
        {
            this.ToTable("Calificacion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
