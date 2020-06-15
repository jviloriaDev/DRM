using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Traduction_Language
{
    public partial class Spartan_Traduction_LanguageMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Traduction_Language.Spartan_Traduction_Language>
    {
        public Spartan_Traduction_LanguageMap()
        {
            this.ToTable("Spartan_Traduction_Language");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.IdLanguage);
        }
    }
}
