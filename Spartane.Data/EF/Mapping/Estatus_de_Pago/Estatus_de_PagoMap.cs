using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_de_Pago
{
    public partial class Estatus_de_PagoMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_de_Pago.Estatus_de_Pago>
    {
        public Estatus_de_PagoMap()
        {
            this.ToTable("Estatus_de_Pago");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
