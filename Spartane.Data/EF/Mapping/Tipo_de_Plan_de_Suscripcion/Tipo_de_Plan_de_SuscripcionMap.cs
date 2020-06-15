using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_de_Plan_de_Suscripcion
{
    public partial class Tipo_de_Plan_de_SuscripcionMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_de_Plan_de_Suscripcion.Tipo_de_Plan_de_Suscripcion>
    {
        public Tipo_de_Plan_de_SuscripcionMap()
        {
            this.ToTable("Tipo_de_Plan_de_Suscripcion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
