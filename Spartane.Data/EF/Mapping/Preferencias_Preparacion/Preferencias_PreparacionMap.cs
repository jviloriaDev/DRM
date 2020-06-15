using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Preferencias_Preparacion
{
    public partial class Preferencias_PreparacionMap : EntityTypeConfiguration<Spartane.Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion>
    {
        public Preferencias_PreparacionMap()
        {
            this.ToTable("Preferencias_Preparacion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
