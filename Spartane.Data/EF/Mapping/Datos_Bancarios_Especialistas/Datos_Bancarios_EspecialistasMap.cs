using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Datos_Bancarios_Especialistas
{
    public partial class Datos_Bancarios_EspecialistasMap : EntityTypeConfiguration<Spartane.Core.Classes.Datos_Bancarios_Especialistas.Datos_Bancarios_Especialistas>
    {
        public Datos_Bancarios_EspecialistasMap()
        {
            this.ToTable("Datos_Bancarios_Especialistas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
