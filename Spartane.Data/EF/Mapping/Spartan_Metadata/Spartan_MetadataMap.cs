using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Metadata
{
    public partial class Spartan_MetadataMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Metadata.Spartan_Metadata>
    {
        public Spartan_MetadataMap()
        {
            this.ToTable("Spartan_Metadata");
            this.HasKey(a => a.AttributeId);
            this.Ignore(a => a.Id);
        }
    }
}
