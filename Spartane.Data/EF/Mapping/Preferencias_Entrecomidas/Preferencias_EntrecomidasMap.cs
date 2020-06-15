using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Preferencias_Entrecomidas
{
    public partial class Preferencias_EntrecomidasMap : EntityTypeConfiguration<Spartane.Core.Classes.Preferencias_Entrecomidas.Preferencias_Entrecomidas>
    {
        public Preferencias_EntrecomidasMap()
        {
            this.ToTable("Preferencias_Entrecomidas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
