using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Language_Text
{
    public partial class Spartan_Language_TextMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Language_Text.Spartan_Language_Text>
    {
        public Spartan_Language_TextMap()
        {
            this.ToTable("Spartan_Language_Text");
            this.HasKey(a => a.Language_Text_Id);
            this.Ignore(a => a.Id);
        }
    }
}
