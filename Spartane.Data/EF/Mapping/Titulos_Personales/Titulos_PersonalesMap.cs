using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Titulos_Personales
{
    public partial class Titulos_PersonalesMap : EntityTypeConfiguration<Spartane.Core.Classes.Titulos_Personales.Titulos_Personales>
    {
        public Titulos_PersonalesMap()
        {
            this.ToTable("Titulos_Personales");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
