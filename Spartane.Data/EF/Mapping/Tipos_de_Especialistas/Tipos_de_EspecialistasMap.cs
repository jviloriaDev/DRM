using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipos_de_Especialistas
{
    public partial class Tipos_de_EspecialistasMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas>
    {
        public Tipos_de_EspecialistasMap()
        {
            this.ToTable("Tipos_de_Especialistas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
