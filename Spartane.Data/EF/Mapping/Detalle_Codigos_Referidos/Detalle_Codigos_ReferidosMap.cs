using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Codigos_Referidos
{
    public partial class Detalle_Codigos_ReferidosMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos>
    {
        public Detalle_Codigos_ReferidosMap()
        {
            this.ToTable("Detalle_Codigos_Referidos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
