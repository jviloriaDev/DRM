using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Medicos
{
    public partial class MedicosMap : EntityTypeConfiguration<Spartane.Core.Classes.Medicos.Medicos>
    {
        public MedicosMap()
        {
            this.ToTable("Medicos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
