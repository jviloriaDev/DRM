using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Formas_de_Pago
{
    public partial class Formas_de_PagoMap : EntityTypeConfiguration<Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago>
    {
        public Formas_de_PagoMap()
        {
            this.ToTable("Formas_de_Pago");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
