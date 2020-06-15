using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Report_Presentation_Type
{
    public partial class Spartan_Report_Presentation_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>
    {
        public Spartan_Report_Presentation_TypeMap()
        {
            this.ToTable("Spartan_Report_Presentation_Type");
            this.HasKey(a => a.PresentationTypeId);
            this.Ignore(a => a.Id);
        }
    }
}
