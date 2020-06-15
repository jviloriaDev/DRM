using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_System_Language
{
    public partial class Spartan_System_LanguageMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_System_Language.Spartan_System_Language>
    {
        public Spartan_System_LanguageMap()
        {
            this.ToTable("Spartan_System_Language");
            this.HasKey(a => a.System_Language_Id);
            this.Ignore(a => a.Id);
        }
    }
}
